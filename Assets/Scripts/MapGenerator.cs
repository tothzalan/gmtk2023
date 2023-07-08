#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> platforms;
    /// <summary>
    /// 0. buoy collectible
    /// 1. police collectible
    /// 2. store blackout
    /// 3. pub
    /// 4. kebab
    /// 5. dealer
    /// 6. hooker
    /// 7. traffic light
    /// 8. bus station
    /// 9. walk on road (timed car coming)
    /// 10. wet floor
    /// 11. blackout spot
    /// 12. TODO more
    /// </summary>
    [SerializeField]
    private List<GameObject> interestProps;
    public InterestSpawnChanceMap chances = new ();
    private GameManager manager;
    private Transform playerPos;
    private System.Random rand = new ();

    private float lastPlatformX = -platformLength;

    private const int platformLength = 20;

    private int policeCount = 0;

    private int buoyCount = 0;
    private int storeBlackoutCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        playerPos = GameObject.FindWithTag("Player").transform;
        PlacePlatform();
        PlacePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        float playerX = playerPos.position.x;
        if (playerX > lastPlatformX - platformLength)
        {
            PlacePlatform();
        }
    }

    public void PlacePlatform()
    {
        GameObject selected = platforms[rand.Next(platforms.Count)];
        lastPlatformX += platformLength;
        
        // populate map tile
        for (int i = 0; i < selected.transform.childCount; i++)
        {
            GameObject interestPoint = selected.transform.GetChild(i).gameObject;
            PointOfInterest? obj = interestPoint.GetComponent<PointOfInterest>();

            if(obj == null)
                continue;
            int ind = CalculatePropToSpawn(obj);

            if (ind != -1)
            {
                // TODO collectible counter here
                switch (ind)
                {
                    case 0: buoyCount++;
                        break;
                    case 1: policeCount++; 
                        break;
                    case 2: storeBlackoutCount++;
                        break;
                    
                }
                GameObject interest = interestProps[ind];

                Instantiate(interest, interestPoint.transform.position, interestPoint.transform.rotation);
                
            }
        }
        
        Instantiate(selected, new Vector3(lastPlatformX, 0), new Quaternion(0, 0, 0, 0));
    }

    /// <summary>
    /// Determines the prop or collectible to spawn on the map
    /// </summary>
    /// <param name="pointInterest">The interest map</param>
    /// <returns>the index of the prop in the interest list, or -1 if nothing</returns>
    public int CalculatePropToSpawn(PointOfInterest pointInterest)
    {
        double[] ch = new double[interestProps.Count];
        int d = 0;
        if(pointInterest.collectibleBuoySpot)
            ch[d] = chances.douyCollectible;
        d++;
        if(pointInterest.collectiblePoliceSpot)
            ch[d] = chances.policeCollectible;
        d++;
        if(pointInterest.collectibleStoreBlackout)
            ch[d] = chances.storeBlackoutCollectible;
        d++;
        if(pointInterest.pubSpot && storeBlackoutCount > 0)
            ch[d] = chances.pub;
        d++;
        if(pointInterest.kebabSpot && storeBlackoutCount > 0)
            ch[d] = chances.kebab;
        d++;
        if(pointInterest.dealerPoint && policeCount > 0)
            ch[d] = chances.dealer;
        d++;
        if(pointInterest.hookerPoint)
            ch[d] = chances.hooker;
        d++;
        if(pointInterest.trafficLightSpot)
            ch[d] = chances.trafficLight;
        d++;
        if(pointInterest.busStationSpot)
            ch[d] = chances.busStation;
        d++;
        if(pointInterest.walkOnRoadSpot && buoyCount > 0)
            ch[d] = chances.walkOnRoad;
        d++;
        if(pointInterest.wetFloorSpot)
            ch[d] = chances.wetFloor;
        d++;
        if(pointInterest.blackOutSpot)
            ch[d] = chances.blackout;
        d++;

        double chance = rand.NextDouble() * ch.Length;

        for (int i = 0; i < ch.Length; i++)
        {
            if (ch[i] < chance)
                return i;

            chance--;
        }

        return -1;
    }
}

[Serializable]
public class InterestSpawnChanceMap
{
    [Range(0,1)]
    public double douyCollectible;
    [Range(0,1)]
    public double policeCollectible;
    [Range(0,1)]
    public double storeBlackoutCollectible;
    [Range(0,1)]
    public double dealer;
    [Range(0,1)]
    public double hooker;
    [Range(0,1)]
    public double pub;
    [Range(0,1)]
    public double kebab;
    [Range(0,1)]
    public double trafficLight;
    [Range(0,1)]
    public double busStation;
    [Range(0,1)]
    public double walkOnRoad;
    [Range(0,1)]
    public double wetFloor;
    [Range(0,1)]
    public double blackout;
}
