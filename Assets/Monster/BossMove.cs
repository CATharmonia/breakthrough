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
    [SerializeField]
    GameObject player;
    Rigidbody2D rid2d;
    int jumpCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        hp = 200;
        rid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
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
