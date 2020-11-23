using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plot : MonoBehaviour
{
    [Header("keeps track of the plot")]
    [SerializeField] private bool plotTaken = false;

    [Header("text that will appear when hovering above plot")]
    [SerializeField] private TextMeshPro plotText = null;

    public GameObject plantPrefab = null;

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

    private void OnMouseExit()
    {
        plotText.text = "";
    }

    private void OnMouseDown()
    {
        if (plotTaken == false)
        {
            plotTaken = true;
            Instantiate(plantPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
