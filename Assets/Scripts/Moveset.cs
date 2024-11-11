using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveset : MonoBehaviour
{
    public string Name = "GOJO";
    public bool Active = false;

    [NonSerialized] public GameObject LHand;
    [NonSerialized] public GameObject RHand;
    [NonSerialized] public GameObject Body;
    [NonSerialized]  public stats stats;

    private bool dashDB = false;
    private bool CEActive = false;

    [NonSerialized] public float time = 0f;
    [NonSerialized] public Vector3 lastArmAvgPosition;
    [NonSerialized] public float lastArmAvgTime = 0f;

    public float[] Cooldowns = {
        5f,0f, //dash
        1f,0f,//CE punch burn
        5f,0f,//red
        7.5f,0f,//blue
        8f,0f,//teleportation
    };

    void Update()
    {
       time += Time.deltaTime;

       if (Active)
        {
            Dash(); 
            
            if (CEActive)
            {
                if (Cooldowns[3] + time <= Cooldowns[4]) {
                    stats.CE -= 25;
                }
            }
        }
    }

    private void reversalRed(string type,float distance)
    {
        if (type == "Ball")
        {

        }
        else if (type == "Blast") 
        {

        }
    }

    private void amplificationBlue(string type, float size)
    {
        if (type == "Ball")
        {

        }
        else if (type == "Pull")
        {

        }
    }

    private void Dash()
    {
        if (time - Time.deltaTime * 3 != lastArmAvgTime)
        {
            lastArmAvgTime = time;
        }

        Vector3 avgPos = (LHand.GetComponent<Transform>().position - RHand.GetComponent<Transform>().position);
        Vector3 direction = (Body.GetComponent<Transform>().position - avgPos);
        float dist = direction.magnitude;

        float velocity = (avgPos * dist).magnitude;

        if (dist > 3 && stats.stunned == false  && time + 0.3 <= lastArmAvgTime)
        {
            dashDB = true;
            Cooldowns[2] = time;
            Debug.Log("dashing ");
            transform.localPosition += velocity * direction * Time.deltaTime;
        }
    }
}
