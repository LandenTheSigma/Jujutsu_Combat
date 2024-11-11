using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoundHandler : MonoBehaviourPunCallbacks
{
    public List<GameObject> PlayersInRoom = new List<GameObject>();
    public List<GameObject> PlayersAlive = new List<GameObject>();

    public bool roundInProgress = false;
    public TMPro.TMP_Text RoundText;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            InitializePlayers();
        }
    }

    private void InitializePlayers()
    {
        foreach (var player in PhotonNetwork.PlayerList)
        {
            AddPlayerToRoom(player);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        AddPlayerToRoom(newPlayer);
    }
    private void AddPlayerToRoom(Player newPlayer)
    {
        GameObject playerObj = PhotonView.Find(newPlayer.ActorNumber).gameObject;

        PlayersInRoom.Add(playerObj);
        PlayersAlive.Add(playerObj);

        stats playerStats = playerObj.GetComponent<stats>();
        playerStats.OnHealthChanged += CheckPlayerHealth;
    }
    private void CheckPlayerHealth(GameObject player, int health)
    {
        if (health <= 0)
        {
            PlayersAlive.Remove(player);
            Debug.Log(player.name + " has been removed from PlayersAlive.");
        }
    }
}

