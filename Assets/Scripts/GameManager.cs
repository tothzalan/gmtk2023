using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;

    public int toxicity;

    private bool isDeadFlag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int amount)
    {
        money += amount;
        if (money < 0)
        {
            isDeadFlag = true;
            money = 0;
        }
    }

    public void AddToxicity(int amount)
    {
        toxicity = Math.Max(Math.Min(toxicity + amount, 100), 0);
    }

    public bool IsDead => isDeadFlag;
}
