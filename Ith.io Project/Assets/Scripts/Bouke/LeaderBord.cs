using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBord : MonoBehaviour
{
    private Transform entrysContainer;
    private Transform template;
    private List<LeaderBordEntry> leaderBordEntries;
    private List<Transform> leaderBordEntryTransforms;

    private void Awake()
    {
        
        //find the template and the entry container
        entrysContainer = transform.Find("Entrys");
        template = transform.Find("Template");


        if(entrysContainer == null || template == null)
        {
            Debug.LogError("entrysContainer or entry Template not found in this scene");
            return;
        }
        template.gameObject.SetActive(false);

        //here is a by hand made list for testing purpeses

        //leaderBordEntries = new List<LeaderBordEntry>
        //{
        //    new LeaderBordEntry{money = 2348, name = "AAA"},
        //    new LeaderBordEntry{money = 123, name = "ASS"},
        //    new LeaderBordEntry{money = 34524, name = "SAS"},
        //    new LeaderBordEntry{money = 245245, name = "DAS"},
        //    new LeaderBordEntry{money = 4524, name = "AAS"},
        //    new LeaderBordEntry{money = 43255, name = "DAA"},
        //    new LeaderBordEntry{money = 22, name = "SAA"},
        //    new LeaderBordEntry{money = 2, name = "ASD"},
        //    new LeaderBordEntry{money = 1, name = "SAS"},
        //    new LeaderBordEntry{money = 13244, name = "DAD"},
        //};

        string jsonString = PlayerPrefs.GetString("HighScoreTable");
        LeaderBordScores leaderBordScores = JsonUtility.FromJson<LeaderBordScores>(jsonString);

        for (int i = 0; i < leaderBordScores.leaderBordEntries.Count; i++)
        {
            for (int j = i + 1; j < leaderBordScores.leaderBordEntries.Count; j++)
            {
                if (leaderBordScores.leaderBordEntries[j].money > leaderBordScores.leaderBordEntries[i].money)
                {
                    //swap the 2 around
                    LeaderBordEntry lbe = leaderBordScores.leaderBordEntries[i];
                    leaderBordScores.leaderBordEntries[i] = leaderBordScores.leaderBordEntries[j];
                    leaderBordScores.leaderBordEntries[j] = lbe;
                }
            }
        }

        leaderBordEntryTransforms = new List<Transform>();
        foreach(LeaderBordEntry leaderBordEntry in leaderBordScores.leaderBordEntries)
        {
            CreateLeaderBordTransform(leaderBordEntry, leaderBordEntryTransforms);
        }


        //LeaderBordScores leaderBordScores_ = new LeaderBordScores { leaderBordEntries = leaderBordEntries };
        //string json = JsonUtility.ToJson(leaderBordScores_);
        //PlayerPrefs.SetString("HighScoreTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("HighScoreTable"));

    }

    private void CreateLeaderBordTransform(LeaderBordEntry leaderBordEntry, List<Transform> transformlist)
    {
        Transform entryTransform = Instantiate(template, entrysContainer);
        entryTransform.gameObject.SetActive(true);

        //get the right rank string for eatch postions
        int rank = transformlist.Count + 1;
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

        //get the money text 
        int money = leaderBordEntry.money;
        entryTransform.Find("mony text").GetComponent<TMP_Text>().text = money.ToString();

        //get the name text
        string name = leaderBordEntry.name;
        entryTransform.Find("Name text").GetComponent<TMP_Text>().text = name;

        transformlist.Add(entryTransform);

    }

    private class LeaderBordScores
    {
        public List<LeaderBordEntry> leaderBordEntries;
    }

    [System.Serializable]
    private class LeaderBordEntry
    {
        public int money;
        public string name;
    }
}


