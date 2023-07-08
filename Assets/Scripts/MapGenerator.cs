using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms;
    private Transform playerPos;
    private System.Random rand = new ();

    private float lastPlatformX;

    private const int platformLength = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        for (int i = 0; i < 4; i++)
        {
            PlacePlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = playerPos.position.x;
        if (playerX > lastPlatformX - platformLength * 3)
        {
            PlacePlatform();
        }
    }

    public void PlacePlatform()
    {
        GameObject selected = platforms[rand.Next(platforms.Count)];
        lastPlatformX += platformLength;

        Instantiate(selected, new Vector3(lastPlatformX, 0), new Quaternion(0, 0, 0, 0));
    }
}
