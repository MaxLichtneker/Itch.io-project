using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private DayNightCyle dayNightCyle;

    [Header("Image that shows what the time currently is")]
    [SerializeField] private Image currentTimeVisual;


    [Header("Tmpro text that shows what day it is")]
    [SerializeField] private TextMeshProUGUI dayText = null;

    void Start()
    {
        dayNightCyle = FindObjectOfType<DayNightCyle>();
        currentTimeVisual.fillAmount = 0.5f;
    }

    void Update()
    {
        SetDayToText();

        SetImageFill();
    }

    private void SetDayToText()
    {
        dayText.text = dayNightCyle.days.ToString();
    }

    private void SetImageFill()
    {
        currentTimeVisual.fillAmount = dayNightCyle.time / 300.0f;
    }

}
