using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public static GroundManager Instance => instance;

    [Space, SerializeField]
    private Transform environment;

    private static GroundManager instance;
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
    public List<GameObject> SpawnPlatform(LevelInfo _levelInfo)
    {
        int platformSize = _levelInfo.platformSize;
        List<GameObject> platforms = _levelInfo.platformList;
        GameObject endPlatform = _levelInfo.endPlatform;
        Vector3 targetPos = Vector3.zero;

        List<GameObject> returnList = new List<GameObject>();
        for (int i = 0; i < platformSize; i++)
        {
            int randomPlatformIndex = Random.Range(0, platforms.Count);

            GameObject platform = Instantiate(
                platforms[randomPlatformIndex],
                targetPos,
                Quaternion.identity);

            platform.transform.SetParent(environment);
            platform.name = $"Platform {i+1}";
            returnList.Add(platform);

            if (i != platformSize - 1)
            {
                targetPos = new Vector3(
                    targetPos.x, 
                    targetPos.y, 
                    targetPos.z + _levelInfo.basicPlatformLength);
            }
        }

        if (_levelInfo.spawnEndPlatform)
        {
            targetPos = new Vector3(
                targetPos.x, 
                targetPos.y, 
                targetPos.z + _levelInfo.endPlatformLength);

            GameObject lastPlatform = Instantiate(
                endPlatform,
                targetPos,
                Quaternion.identity);

            lastPlatform.transform.SetParent(environment);
            lastPlatform.name = "END PLATFORM";
            returnList.Add(lastPlatform);
        }
        return returnList;
    }
}
