using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMAX : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("chara");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().bulletGaugeMax = 100;
            player.GetComponent<Player>().bulletGauge = 100;
            Destroy(this.gameObject);
        }
    }
}
