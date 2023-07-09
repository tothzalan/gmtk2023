#nullable enable
using System;
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
    /// 6. mugger
    /// 7. traffic light
    /// 8. bus station
    /// 9. walk on road (timed car coming)
    /// 10. wet floor
    /// 11. beer
    /// 12. car spot
    /// </summary>
    [SerializeField]
    private List<GameObject> interestProps;
    public InterestSpawnChanceMap chances = new ();
    private GameManager manager;
    private Transform playerPos;
    private System.Random rand = new ();

    private float lastPlatformX = -platformLength * 2;

    private const int platformLength = 20;

    public int policeCount = 0;

    public int buoyCount = 0;
    public int storeBlackoutCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        playerPos = GameObject.FindWithTag("Player").transform;
        PlacePlatform(false);
        PlacePlatform(false);
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

    public void ReloadPlatforms()
    {
        var activePlatforms = GameObject.FindGameObjectsWithTag("Platform");

        for (int i = 0; i < activePlatforms.Length; i++)
        {
            Destroy(activePlatforms[i]);
        }

        var activeProps = GameObject.FindGameObjectsWithTag("Prop");
        
        for (int i = 0; i < activeProps.Length; i++)
        {
            Destroy(activeProps[i]);
        }

        lastPlatformX = -platformLength * 2;

        playerPos.position = new Vector3(0, playerPos.position.y);
        
        PlacePlatform(false);
        PlacePlatform(false);
        PlacePlatform();
    }

    public void ReloadFromBus()
    {
        ReloadPlatforms();
        
        // TODO: add bus spawn and stop spawn to spawn point aka: 0, 0, 0
    }

    private void PlacePlatform(bool spawnProp = true)
    {
        GameObject selected = platforms[rand.Next(platforms.Count)];
        lastPlatformX += platformLength;
        GameObject newObject = Instantiate(selected, new Vector3(lastPlatformX, 0), new Quaternion(0, 0, 0, 0));

        if (!spawnProp)
            return;
        // populate map tile
        for (int i = 0; i < newObject.transform.childCount; i++)
        {
            GameObject interestPoint = newObject.transform.GetChild(i).gameObject;
            PointOfInterest? obj = interestPoint.GetComponent<PointOfInterest>();

            if(obj == null)
                continue;
            int ind = CalculatePropToSpawn(obj);

            if (ind != -1)
            {
                // collectible counter here
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
        
        
    }

    /// <summary>
    /// Determines the prop or collectible to spawn on the map
    /// </summary>
    /// <param name="pointInterest">The interest map</param>
    /// <returns>the index of the prop in the interest list, or -1 if nothing</returns>
    private int CalculatePropToSpawn(PointOfInterest pointInterest)
    {
        double[] ch = new double[interestProps.Count];
        int d = 0;
        double sum = 0;
        if (pointInterest.collectibleBuoySpot)
        {
            ch[d] = chances.douyCollectible;
            sum++;
        }
        d++;
        if (pointInterest.collectiblePoliceSpot)
        {
            ch[d] = chances.policeCollectible;
            sum++;
        }
        d++;
        if (pointInterest.collectibleStoreBlackout)
        {
            ch[d] = chances.storeBlackoutCollectible;
            sum++;
        }
        d++;
        if (pointInterest.pubSpot && storeBlackoutCount > 0)
        {
            ch[d] = chances.pub;
            sum++;
        }
        d++;
        if (pointInterest.kebabSpot && storeBlackoutCount > 0)
        {
            ch[d] = chances.kebab;
            sum++;
        }
        d++;
        if (pointInterest.dealerPoint && policeCount > 0)
        {
            ch[d] = chances.dealer;
            sum++;
        }
        d++;
        if (pointInterest.muggerPoint)
        {
            ch[d] = chances.mugger;
            sum++;
        }
        d++;
        if (pointInterest.trafficLightSpot)
        {
            ch[d] = chances.trafficLight;
            sum++;
        }
        d++;
        if (pointInterest.busStationSpot)
        {
            ch[d] = chances.busStation;
            sum++;
        }
        d++;
        if (pointInterest.walkOnRoadSpot && buoyCount > 0)
        {
            ch[d] = chances.walkOnRoad;
            sum++;
        }
        d++;
        if (pointInterest.wetFloorSpot)
        {
            ch[d] = chances.wetFloor;
            sum++;
        }
        d++;
        if (pointInterest.beerSpot)
        {
            ch[d] = chances.beer;
            sum++;
        }

        d++;
        if (pointInterest.carSpot)
        {
            ch[d] = chances.car;
            sum++;
        }

        double chance = rand.NextDouble() * sum;

        for (int i = 0; i < ch.Length; i++)
        {
            if (ch[i] >= chance)
                return i;

            chance -= ch[i];
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
    public double mugger;
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
    [Range(0, 1)] 
    public double beer;
    [Range(0, 1)] 
    public double car;
}
