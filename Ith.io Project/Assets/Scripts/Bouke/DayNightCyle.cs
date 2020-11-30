using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCyle : MonoBehaviour
{
    [SerializeField] private Gradient LightColor;
    [SerializeField] private GameObject light;

    private int days;

    public int Days => days;

    [Header("set here the Time in what is a full day and night cyle in seconds")]
    public float maxTime;

    public float time = 50;

    private bool canChangeDay = true;

    

    private void Update()
    {
        if(time > maxTime)
        {
            time = 0;
        }
        if((int)time == maxTime / 2 && canChangeDay)
        {
            canChangeDay = false;
            days++;
            
        }
        if((int)time == maxTime / 2 + 5)
        {
            canChangeDay = true;
        }

        

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = LightColor.Evaluate(time / maxTime);
    }
}
