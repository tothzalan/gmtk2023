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
        FormatScore(gameManager.Score);
        FormatToxicity(gameManager.Toxicity);
        FormatMoney(gameManager.Money);
    }

    private void FormatScore(int amount)
    {
        score.text = $"<mark=#000000aa>${amount}</mark>";
    }

    private void FormatToxicity(int amount)
    {
        toxicity.text = $"<mark=#000000aa>{amount}%</mark>";
    }

    private void FormatMoney(int amount)
    {
        money.text = $"<mark=#000000aa><${amount}</mark>";
    }

}
