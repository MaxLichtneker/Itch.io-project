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
    public int maxLeaderbordEntries;

    public static LeaderBord instance;

    public static bool gameEnd;

    private void Awake()
    {
        instance = this;

        //find the template and the entry container
        entrysContainer = transform.Find("Entrys");
        template = transform.Find("Template");

        

        if (gameEnd == true)
        {
            AddLeaderBordEntry(HoldLeaderBordInfo.instance.money, HoldLeaderBordInfo.instance.name);
            gameEnd = false;
        }

        if (entrysContainer == null || template == null)
        {
            Debug.LogError("entrysContainer or entry Template not found in this scene");
            return;
        }
        template.gameObject.SetActive(false);


        //AddLeaderBordEntry(444, "AAA");
        //AddLeaderBordEntry(444, "AAA");
        //AddLeaderBordEntry(444, "AAA");
        //AddLeaderBordEntry(444, "AAA");

        //verwijder dit na dat je een keer hebt gespeeld als een test
        LeaderBordScores leaderBordScores_ = new LeaderBordScores { leaderBordEntries = leaderBordEntries };
        string json = JsonUtility.ToJson(leaderBordScores_);
        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();

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

        if (leaderBordScores.leaderBordEntries.Count > maxLeaderbordEntries)
        {
            leaderBordScores.leaderBordEntries.RemoveAt(leaderBordScores.leaderBordEntries.Count - 1);
        }

        leaderBordEntryTransforms = new List<Transform>();
        foreach (LeaderBordEntry leaderBordEntry in leaderBordScores.leaderBordEntries)
        {
            CreateLeaderBordTransform(leaderBordEntry, leaderBordEntryTransforms);
        }




        LeaderBordScores leaderBordScores_ = new LeaderBordScores { leaderBordEntries = leaderBordEntries };
        string json = JsonUtility.ToJson(leaderBordScores_);
        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("HighScoreTable"));

    }

    private void CreateLeaderBordTransform(LeaderBordEntry leaderBordEntry, List<Transform> transformlist)
    {
        Transform entryTransform = Instantiate(template, entrysContainer);
        entryTransform.gameObject.SetActive(true);

        
        

        //get the money text 
        int money = leaderBordEntry.money;
        entryTransform.Find("mony text").GetComponent<TMP_Text>().text = money.ToString();

        //get the name text
        string name = leaderBordEntry.name;
        entryTransform.Find("Name text").GetComponent<TMP_Text>().text = name;

        transformlist.Add(entryTransform);

    }
    public void AddLeaderBordEntry(int money, string name)
    {
        //create the new leaderbord entry
        LeaderBordEntry leaderBordEntry = new LeaderBordEntry { money = money, name = name };


        // load and saved leaderbord
        string jsonString = PlayerPrefs.GetString("HighScoreTable");
        LeaderBordScores leaderBordScores = JsonUtility.FromJson<LeaderBordScores>(jsonString);

        

        //add new entry
        leaderBordScores.leaderBordEntries.Add(leaderBordEntry);

        //save 
        string json = JsonUtility.ToJson(leaderBordScores);
        PlayerPrefs.SetString("HighScoreTable", json);
        PlayerPrefs.Save();
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


