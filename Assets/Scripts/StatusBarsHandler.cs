using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusBarsHandler : MonoBehaviour
{
    private GameManager gameManager;
    private TMP_Text toxicity;
    private TMP_Text money;
    private TMP_Text score;

    void Start() 
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        toxicity = GetComponentsInChildren<TMP_Text>()[0];
        money = GetComponentsInChildren<TMP_Text>()[1];
        score = GetComponentsInChildren<TMP_Text>()[2];
    }

    void Update()
    {
        score.text = gameManager.Score.ToString();
        FormatToxicity(gameManager.Toxicity);
        FormatMoney(gameManager.Money);
    }

    private void FormatToxicity(int amount)
    {
        toxicity.text = $"{amount}%";
    }

    private void FormatMoney(int amount)
    {
        money.text = $"${amount}";
    }

}
