using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private Animation animation;
    private static bool played;
    public GameObject backToMenuBtn;
    void Start()
    {
        gameObject.SetActive(false);
        animation = gameObject.GetComponent<Animation>();
        backToMenuBtn.SetActive(false);
        played = false;
    }

    public void Death()
    {
        gameObject.SetActive(true);
        if(!played)
            animation.Play("DeathScreen");
        played = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateBackButton()
    {
        backToMenuBtn.SetActive(true);
    }
}
