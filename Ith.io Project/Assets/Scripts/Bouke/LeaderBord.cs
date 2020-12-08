using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBord : MonoBehaviour
{
    public Transform entrysContainer;
    public Transform template;

    private void Awake()
    {
        entrysContainer = transform.Find("Entrys");
        template = transform.Find("Template");


        if(entrysContainer == null || template == null)
        {
            Debug.LogError("entrysContainer or entry Template not found in this scene");
            return;
        }
        template.gameObject.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(template, entrysContainer);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankText;
            switch (rank)
            {
                default:
                    rankText = rank + "TH"; break;

                case 1: rankText = "1ST"; break;
                case 2: rankText = "2ND"; break;
                case 3: rankText = "3RD"; break;
            }
            entryTransform.Find("Positie text").GetComponent<TMP_Text>().text = rankText;

        }
       
    }

    private class LeaderBordEntry
    {
        public int money;
        public int name;
    }
}


