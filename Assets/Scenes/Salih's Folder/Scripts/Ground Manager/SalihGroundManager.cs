using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalihGroundManager : MonoBehaviour
{
    [Space, SerializeField]
    private int platformCount;

    [Space, SerializeField]
    private float zOffSet;

    [Space, SerializeField]
    private List<GameObject> Platforms;

    [Space, SerializeField]
    private Transform environment;

    private static SalihGroundManager instance;
    public static SalihGroundManager Instance => instance;

    Vector3 targetPos = Vector3.zero;

    //[Space, SerializeField]
    //private GameObject endPlatform;

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

    public List<GameObject> SpawnPlatforms()
    {
        int lastRandom = -1;
        List<GameObject> returnList = new List<GameObject>();

        for (int i = 1; i <= platformCount - 1; i++)
        {
            int randomPlatformIndex = RandomIndex();

            //2 defa aynı yolu spawn etmesin diye
            if (randomPlatformIndex != lastRandom)
            {
                GameObject temp = SpawnPlatforms(randomPlatformIndex);
                returnList.Add(temp);
                lastRandom = randomPlatformIndex;
            }
            else
            {
                platformCount++;
            }

        }

        //son platform oluşturma
        //son index her zaman end platform olmak zorunda
        GameObject temp2 = SpawnPlatforms(platformCount - 1);
        returnList.Add(temp2);

        return returnList;
    }

    public int RandomIndex()
    {
        int i = Random.Range(0, Platforms.Count - 1);

        return i;
    }

    public GameObject SpawnPlatforms(int index)
    {
        GameObject endP = Instantiate(Platforms[index], targetPos, Quaternion.identity) as GameObject;
        endP.transform.SetParent(environment);
        targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z + zOffSet);

        return endP;
    }
}
