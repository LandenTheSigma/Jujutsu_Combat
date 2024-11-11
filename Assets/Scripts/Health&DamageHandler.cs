using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UIElements;
using System;

public class stats : MonoBehaviour
{
    public float maxHealth = 100f;
    public int CE = 1000;
    public bool isAlive = false;
    public Vector3 spawn = new Vector3(0,10,0);
    public GameObject player;
    public bool stunned = false;

    public event Action<GameObject, int> OnHealthChanged;

    private float time;
    private float lastCEUpdate;

    public float Health
    {
        get { return Health; }
        private set
        {
            Health = Mathf.Clamp(value, 0f, maxHealth);
            OnHealthChanged?.Invoke(gameObject, (int)Health);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (isAlive) {
           if (lastCEUpdate + 1 <= time)
            {
                CE += 15;
            }
        }
    }

    private void Start()
    {
        player = this.gameObject;
    }

    public void changeHealth(float amt)
    {
        if (isAlive)
        {
            Health -= amt;
            onHealthUpdated();
        }
    }

    private void onHealthUpdated()
    {
        if (Health <= 0f) {
            isAlive = false;

            player.GetComponent<Transform>().position = spawn;
            Health = 100f;
        }
    }

    public void Spawn()
    {
        player.GetComponent<Transform>().position = spawn;
        Health = 100f;
        CE = 1000;
    }
}
