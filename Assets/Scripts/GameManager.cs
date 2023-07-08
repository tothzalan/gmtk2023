using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    private int money;
    public int Money { get { return money; } }

    private int toxicity;
    public int Toxicity { get { return toxicity; } }

    private int ctl = 0;
    [SerializeField]
    private int score = 0;
    
    public int Score { get { return score; } }

    private bool dead = false;
    public bool Dead { get { return dead; } set { dead = value; }}

    public bool IsBlackOut { get; private set; }

    private readonly System.Random rand = new ();

    [SerializeField]
    private GameObject InventoryManagerGameObject;
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start() // This should only exist when the actual game loads, not on menu
    {
        inventoryManager = InventoryManagerGameObject.GetComponent<InventoryManager>();
    }

    private double ScoreMultiplier => (double)score / 100; // score reward/punishment should go up according
    public float SpeedMultiplier => (float)score / 100; // for speed multi 

    // Update is called once per frame
    void Update()
    {
        if (rand.NextDouble() <= 0.05)
        {
            IsBlackOut = true;
        }
        
        if (dead)
            return;
        ctl++;
        if (ctl == 120)
        {
            AddScore(2); // score per sec here
            ctl = 0;
        }
    }

    public void EndBlackOut()
    {
        IsBlackOut = false;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
        if (money < 0)
        {
            dead = true;
            money = 0;
        }
    }

    public void AddToxicity(int amount)
    {
        toxicity = Math.Max(Math.Min(toxicity + amount, 100), 0);
    }

    public void AddScore(int amount)
    {
        if (!isPaused)
        {
            score += (int)(amount * (1 + ScoreMultiplier));
        }
    }

}
