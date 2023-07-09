using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public Animation animation;
    public static bool played;
    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
        played = false;
    }

    public void Death()
    {
        if(!played)
            animation.Play("DeathScreen");
        played = true;
    }
}
