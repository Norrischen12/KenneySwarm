using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveCaller : MonoBehaviour
{
    public TMP_Text myTextMeshPro;
    public GameObject Spawner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myTextMeshPro.text = Spawner.GetComponent<EnemySpawner>().currWave.ToString();
    }
}
