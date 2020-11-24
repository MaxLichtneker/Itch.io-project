using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plot : MonoBehaviour
{
    public CropState cropState;

    [Header("keeps track of the plot")]
    [SerializeField] private bool plotTaken = false;

    [Header("text that will appear when hovering above plot")]
    [SerializeField] private TextMeshPro plotText = null;

    public GameObject plantPrefab = null;

    private GameObject plant;

    private void Update()
    {
        if (plotTaken)
        {
            cropState = GetComponentInChildren<Plant>().cropState;
        }
    }

    //shows text when the mouse is over the plot
    private void OnMouseOver()
    {
        if(plotTaken == false)
        {
            plotText.text = "Plant seed";
        }
        else if (plotTaken)
        {
            plotText.text = "plot taken";
        }
    }

    //sets empties the string so when the mouse is not over plot text is not showing
    private void OnMouseExit()
    {
        plotText.text = "";
    }

    //when the player clicks on the plot it will plant a seed
    private void OnMouseDown()
    {
        if (plotTaken == false)
        {
            plotTaken = true;
            var child = Instantiate(plantPrefab, gameObject.transform.position, gameObject.transform.rotation);

            child.transform.parent = gameObject.transform;
        }
    }
}
