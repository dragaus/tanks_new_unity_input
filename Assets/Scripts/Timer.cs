using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float minutes;
    public float seconds;
    float time;
    public bool isCountdown;
    public TextMeshProUGUI timerText;
    public UnityAction finishCountDown;

    private void OnDestroy()
    {
        instance = null;
    }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        time = minutes * 60 + seconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountdown && time >= 0)
        {
            time -= Time.deltaTime;
            timerText.text = $"{Mathf.FloorToInt(time / 60f):00}:{time % 60:00}";
            if (time < 0) 
            {
                timerText.text = "00:00";
                finishCountDown();
            }
        }
        else if(!isCountdown)
        { 
            time += Time.deltaTime;
        }
    }
}
