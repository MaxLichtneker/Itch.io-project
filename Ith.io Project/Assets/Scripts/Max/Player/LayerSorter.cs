using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour
{
    [SerializeField] private int sortingOrder = 5000;

    [SerializeField]
    private int offset = 0;

    private Renderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        Sorter();
    }

    //sorts the layer of the player depending on the position
    private void Sorter()
    {
        playerRenderer.sortingOrder = (int)(sortingOrder - transform.position.y - offset);
    }
}
