using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int lifetime;
    int timeout;

    public bool isPaused;
    [SerializeField]
    private int money = 50;
    public int Money { get { return money; } }

    [SerializeField]
    private int toxicity = 50;

    public int Toxicity { get { return toxicity; } }

    private int ctl = 0;
    [SerializeField]
    private int score = 0;
    
    public int Score { get { return score; } }

    private bool dead = false;
    public bool Dead { get { return dead; } set { dead = value; }}
    public string killedBy = "";

    public bool IsBlackOut { get; private set; }

    private readonly System.Random rand = new ();

    [SerializeField]
    private GameObject InventoryManagerGameObject;
    private GameObject playerPrefab;
    public InventoryManager inventoryManager;
    public Transform playerPos;

    [SerializeField]
    public GameObject carPrefab;

    [SerializeField]
    public GameObject deathScreen;
    private DeathScreen deathScreenScript;

    // Start is called before the first frame update
    void Start() // This should only exist when the actual game loads, not on menu
    {
        inventoryManager = InventoryManagerGameObject.GetComponent<InventoryManager>();
        playerPos = GameObject.FindWithTag("Player").transform;
        playerPrefab = GameObject.FindWithTag("Player");        
        
        lifetime = 0;
        timeout = 0;

        deathScreenScript = deathScreen.GetComponent<DeathScreen>();
    }

    private double ScoreMultiplier => Math.Abs((double)score / 100); // score reward/punishment should go up according
    public float SpeedMultiplier => (float)Math.Floor((double)(score / 100)); // for speed multi 

    // Update is called once per frame
    void Update()
    {
        if (rand.NextDouble() <= 0.05)
        {
            IsBlackOut = true;
        }

        if (dead)
        {
            deathScreenScript.Death();
            Time.timeScale = 0f;
            return;
        }
        ctl++;
        if (ctl == 120)
        {
            AddScore(2); // score per sec here
            ctl = 0;
        }

        SpawnCar();
    }

    public void SpawnCar(){
        Vector3 randomSpawnPoint = new Vector3(playerPrefab.transform.position.x-30.0f, UnityEngine.Random.Range(-0.5f,0.5f) , 0);
        if(timeout != 0){
            timeout--;
        }
        if(timeout == 0 && UnityEngine.Random.Range(0,2000) == 1){
            Instantiate(carPrefab, randomSpawnPoint, Quaternion.identity);
            timeout = 720;
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
            killedBy = "Brokeness";
            dead = true;
            money = 0;
        }
    }

    public void AddToxicity(int amount)
    {
        toxicity = Math.Max(Math.Min(toxicity + amount, 100), 0);
        if(toxicity > 80)
        {
            killedBy = "Toxicity";
            dead = true;
        }
    }

    public void AddScore(int amount)
    {
        if (!isPaused)
        {
            score += (int)(amount * (1 + ScoreMultiplier));
        }
    }
}
