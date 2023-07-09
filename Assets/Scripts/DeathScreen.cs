using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private Animation animation;
    private static bool played;
    public GameObject backToMenuBtn;
    private GameObject ui;
    void Start()
    {
        ui = GameObject.FindWithTag("UICanvas");
        gameObject.SetActive(false);
        animation = gameObject.GetComponent<Animation>();
        backToMenuBtn.SetActive(false);
        played = false;
    }

    public void Death()
    {
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
