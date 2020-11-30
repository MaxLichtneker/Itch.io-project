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
        //change the day number when it is mid night
        if((int)time == maxTime / 2 && canChangeDay)
        {
            canChangeDay = false;
            days++;
            
        }
        // make it able to change the day agian
        if((int)time == maxTime / 2 + 5)
        {
            canChangeDay = true;
        }

        

        time += Time.deltaTime;
        //change the light with the cradient as color
        light.GetComponent<Light2D>().color = LightColor.Evaluate(time / maxTime);
    }
}
