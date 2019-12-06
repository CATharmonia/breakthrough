using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : Enemy
{
    [SerializeField]
    float walkPower = 7.0f;
    [SerializeField]
    float jumpPower = 16.0f;
    [SerializeField]
    float span = 9;
    float timer = 0;
    GameObject player;
    Rigidbody2D rid2d;
    int jumpCnt = 0;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        player = GameObject.Find("chara");
        power = 5;
        hp = 200;
        rid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (dis < 25)
        {
            if (hp <= 0)
            {
                aud.Play();
                Destroy(this.gameObject);
            }
            int key;
            timer += Time.deltaTime;
            if (timer > span)
            {

                if (player.transform.position.x < this.transform.position.x)
                {
                    key = -1;
                }
                else
                {
                    key = 1;
                }
                transform.localScale = new Vector3(-1 * key * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1);
                if (jumpCnt == 2)
                {
                    rid2d.velocity = new Vector3(key, 8, 0).normalized * jumpPower;
                    jumpCnt = -1;
                    timer = -4;
                }
                else
                {
                    rid2d.velocity = new Vector3(key, 8, 0).normalized * walkPower;
                    timer = 0;
                }
                jumpCnt++;
            }
        }
    }
}
