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

    public float time = 50;

    private bool canChangeDay = true;

    

    private void Update()
    {
        if(time > 500)
        {
            time = 0;
        }
        if((int)time == 250 && canChangeDay)
        {
            canChangeDay = false;
            days++;
        }
        if((int)time == 255)
        {
            canChangeDay = true;
        }

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = LightColor.Evaluate(time * 0.002f);
    }
}
