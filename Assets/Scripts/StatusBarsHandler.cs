using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusBarsHandler : MonoBehaviour
{
    private TMP_Text slider;
    private TMP_Text money;
    private TMP_Text score;

    void Start() 
    {
        slider = GetComponentsInChildren<TMP_Text>()[0];
        money = GetComponentsInChildren<TMP_Text>()[1];
        score = GetComponentsInChildren<TMP_Text>()[2];
        slider.text = "0";
        money.text = "0 $"; 
        score.text = "0";
    }

    void Update()
    {
    }
}
