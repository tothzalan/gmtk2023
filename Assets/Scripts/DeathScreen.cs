using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private GameManager gameManager;
    private Animation animation;
    private static bool played;
    private GameObject ui;
    private TMP_Text score;
    public GameObject backToMenuBtn;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        score = GetComponentsInChildren<TMP_Text>()[0];
        ui = GameObject.FindWithTag("UICanvas");
        gameObject.SetActive(false);
        animation = gameObject.GetComponent<Animation>();
        backToMenuBtn.SetActive(false);
        played = false;
    }

    public void Death()
    {
        score.text = "Score: " + gameManager.Score.ToString();
        ui.SetActive(false);
        gameObject.SetActive(true);
        if(!played)
            animation.Play("DeathScreen");
        played = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ActivateBackButton()
    {
        backToMenuBtn.SetActive(true);
    }
}
