using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCyle : MonoBehaviour
{
    [SerializeField] private Gradient LightColor;
    [SerializeField] private GameObject light;

    public int days;

    public List<Transform> lightPos;
   

    public float t;
    

    //public int Days => days;

    [Header("set here the Time in what is a full day and night cyle in seconds")]
    public float maxTime;

    public float time = 50;

    private bool canChangeDay = true;

    private void Start()
    {

        //transform.position = lightPos[1].position;
        //isAtPos2 = true;
        t = 0.50f;
    }

    private void Update()
    {
        if (time > maxTime)
        {
            time = 0;
        }
        //change the day number when it is mid night
        if ((int)time == maxTime / 2 && canChangeDay)
        {
            canChangeDay = false;
            days++;

        }
        // make it able to change the day agian
        if ((int)time == maxTime / 2 + 5)
        {
            canChangeDay = true;
        }

        if (t >= 1)
        {
            t = 0;
        }
    
        t += Time.deltaTime / 300;
            transform.position = Vector3.Lerp(lightPos[0].position, lightPos[1].position,t);
        
        

        time += Time.deltaTime;
        //change the light with the cradient as color
        light.GetComponent<Light2D>().color = LightColor.Evaluate(time / maxTime);
    }
}
