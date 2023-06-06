using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roadgenerator : MonoBehaviour
{
    public GameObject RoadPrefab;
    private List<GameObject> roads = new List<GameObject>();

    public float speed = 0f;
    public float maxSpeed = 5f;
    public int maxRoadCount = 10;

    private List<Vector3> vPos = new List<Vector3>() 
    {
        new Vector3(0, -3, 0), 
        new Vector3(3, 0, 0),
        new Vector3(0, 3, 0),
        new Vector3(-3, 0, 0),
     };
    private List<Quaternion> vRot = new List<Quaternion>()
    {
        new Quaternion(0, 0, 0, 0),
        new Quaternion(0, 0, -90, -90),
        new Quaternion(0, 0, 180, 0),
        new Quaternion(0, 0, 90, 90)
    };

    void Start()
    {
        ResetLevel();
        speed = maxSpeed;
    }


    void Update()
    {
        if (speed == 0) { return; }

        foreach (GameObject road in roads)
        {
            road.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }

        if (roads[0].transform.position.z < -15)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
            CreateNexrRoad();
        }
    }
    
    void ResetLevel()
    {
        speed= 0f;
        while (roads.Count > 0)
        {
            Destroy(roads[0]);
            roads.RemoveAt(0);
        }
        for (int i = 0; i < maxRoadCount; i++)
        {
            CreateNexrRoad();
        }
    }

    void CreateNexrRoad()
    {
        Vector3 pos = vPos[0];
        GameObject go = Instantiate(RoadPrefab, pos, Quaternion.identity);

        if (roads.Count > 0)
        {
            go = RoadPosition(go);
        }

        go.transform.SetParent(transform);
        roads.Add(go);
    }

    private GameObject RoadPosition(GameObject go)
    {
        int numVector = Random.Range(0, vPos.Count - 1);
        float lastVector = roads[roads.Count - 1].transform.position.z;
        Vector3 pos = vPos[numVector] + new Vector3(0, 0, lastVector + Random.Range(8, 11));
        go.transform.position = pos;
        go.transform.rotation = vRot[numVector];
        return go;
    }
}
