using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        GameObject player = GameObject.FindWithTag("Player");
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        Vector2 pos = pm.transform.position;
        transform.position = new Vector2(pos.x, pos.y);

    }
}
