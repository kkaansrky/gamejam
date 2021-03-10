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
    private GameObject platform;

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
            GameObject newPlatform =
                Instantiate(platform, targetPos, Quaternion.identity) as GameObject;
            newPlatform.name = "P" + i;
            newPlatform.transform.SetParent(environment);
            targetPos = new Vector3(targetPos.x, targetPos.y, targetPos.z + zOffSet);
            returnList.Add(newPlatform);
        }
        return returnList;
    }
}
