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
        Vector3 targetPos = Vector3.zero;
        List<GameObject> returnList = new List<GameObject>();

        for (int i = 1; i <= platformCount; i++)
        {
            int randomPlatformIndex = RandomIndex();
            GameObject newPlatform =
                Instantiate(Platforms[randomPlatformIndex], targetPos, Quaternion.identity) as GameObject;
            newPlatform.name = "P" + i;
            newPlatform.transform.SetParent(environment);
            targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z + zOffSet);
            returnList.Add(newPlatform);
        }
        return returnList;
    }

    public int RandomIndex()
    {
        int i = Random.Range(0, Platforms.Count);

        return i;
    }
}
