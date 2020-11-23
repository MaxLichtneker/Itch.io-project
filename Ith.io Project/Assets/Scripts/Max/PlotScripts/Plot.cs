using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [SerializeField] private bool plotTaken = false;

    public GameObject plantPrefab = null;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        
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
