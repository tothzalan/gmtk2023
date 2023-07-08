using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Credit
{
    private string name;
    private string contribution;
#nullable enable
    private string? url;
    private string? licence;
#nullable disable

    public Credit(string name, string contribution)
    {
        this.name = name;
        this.contribution = contribution;
    }

    public Credit(string name, string contribution, string url, string licence)
    {
        this.name = name;
        this.contribution = contribution;
        this.url = url;
        this.licence = licence;
    }

    public override string ToString()
    {
        //if(url != null)
        //    return $"{name} {contribution} {url} {licence}";
        return $"{name} {contribution}";
    }
}

public class Credits : MonoBehaviour
{
    [SerializeField]
    private TextAsset creditsFile;
    private List<Credit> credits;

    [SerializeField]
    private Transform scrollViewContent;

    [SerializeField]
    private TMP_Text defaultTextPrefab;

    void Start()
    {

        credits = new List<Credit>();
        string[] lines = creditsFile.text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        foreach(var line in lines)
        {
            string[] bits = line.Split(',');
            if(bits.Length == 2)
                credits.Add(new Credit(bits[0], bits[1]));
            else
                credits.Add(new Credit(bits[0], bits[1], bits[2], bits[3]));
        }
        foreach(var credit in credits)
        {
            defaultTextPrefab.text = credit.ToString();
            Instantiate(defaultTextPrefab, scrollViewContent);
        }
    }

    void Update()
    {
        
    }
}
