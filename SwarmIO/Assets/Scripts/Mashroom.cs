using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mashroom : MonoBehaviour
{
    public GameObject collectAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().pickUpKey();
            collectAudio.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
