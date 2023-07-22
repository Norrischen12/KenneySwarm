using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSpawner : MonoBehaviour
{

    public Transform location1;
    public Transform location2;
    public Transform location3;
    public Transform location4;
    public Transform location5;
    public GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        List<Transform> locations = new List<Transform>() { location1, location2, location3, location4, location5 };

        int randomIndex = Random.Range(0, locations.Count - 1);
        GameObject exitSpawn = Instantiate(exit, locations[randomIndex].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
