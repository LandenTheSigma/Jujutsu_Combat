using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float TimeMultiplier;
    [SerializeField] private float StartHour;
    [SerializeField] private TextMeshProUGUI TimeText;

    private DateTime currentTime;

    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(StartHour);
    }

    
    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * TimeMultiplier);

        if (TimeText != null) 
        { 
            TimeText.text = currentTime.ToString("HH:mm");
        }
    }
}
