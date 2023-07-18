using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expValue;
    public Transform player;
    public float floatSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        player = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y);
        transform.position = Vector3.Lerp(transform.position, targetPosition, floatSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            //ADD THE CODE TO ADD EXP AFTER AKIKO ADDS EXP BAR
            Destroy(gameObject);
        }
    }



    public int getExpValue()
    {
        return this.expValue;
    }
    public void setExpValue(int value)
    {
        this.expValue = value;
    }
}
