using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitFunction : MonoBehaviour
{
    private GameObject player;
    public GameObject congrats;
    private void Start()
    {
        player = GameObject.Find("Player");
        GameObject ui = GameObject.Find("Canvas");
        congrats = ui.transform.GetChild(5).gameObject;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.GetComponent<PlayerController>().GetCurrentMushroom() >= 5)
        {
            player.GetComponent<PlayerController>().SetGameOver(true);
            congrats.SetActive(true);

        }
    }

}
