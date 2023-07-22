using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitFunction : MonoBehaviour
{
    private GameObject player;
    public GameObject congrats;
    public GameObject hints;
    private void Start()
    {
        player = GameObject.Find("Player");
        GameObject ui = GameObject.Find("Canvas");
        congrats = ui.transform.GetChild(5).gameObject;
        hints = ui.transform.GetChild(6).gameObject;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.GetComponent<PlayerController>().GetCurrentMushroom() >= 5)
        {
            player.GetComponent<PlayerController>().SetGameOver(true);
            congrats.SetActive(true);

        } else if (collision.gameObject.tag == "Player" && player.GetComponent<PlayerController>().GetCurrentMushroom() < 5)
        {
            hints.SetActive(true);
            StartCoroutine(hintDisappear());
        }
    }
    private IEnumerator hintDisappear()
    {
        yield return new WaitForSeconds(1);
        hints.SetActive(false);
    }
}
