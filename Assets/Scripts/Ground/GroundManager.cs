using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    

    [Space, SerializeField]
    private float zOffSet;

    [Space, SerializeField]
    private List<GameObject> Platforms;

    [Space, SerializeField]
    private Transform environment;

    private static GroundManager instance;
    public static GroundManager Instance => instance;

    private Vector3 targetPos = Vector3.zero;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<GameObject> ManagePlatform()
    {
        int platformCount = Platforms.Count;
        int lastRandom = -1;
        List<GameObject> returnList = new List<GameObject>();

        for (int i = 0; i < platformCount-1; i++)
        {
            int randomPlatformIndex = Random.Range(0, platformCount - 1);

            //2 defa aynı yolu spawn etmesin diye
            if (randomPlatformIndex != lastRandom)
            {
                GameObject tempPlatform = SpawnPlatform(randomPlatformIndex);
                returnList.Add(tempPlatform);
                lastRandom = randomPlatformIndex;
            }
            else
            {
                i--;
            }

        }

        int endPlatformIndex = platformCount -1 ;
        GameObject temp2 = SpawnPlatform(endPlatformIndex);
        returnList.Add(temp2);

        return returnList;
    }

    public GameObject SpawnPlatform(int index)
    {
        GameObject spawnPlatform = Instantiate(Platforms[index], targetPos, Quaternion.identity) as GameObject;
        spawnPlatform.transform.SetParent(environment);
        targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z + zOffSet);

        return spawnPlatform;
    }
}
