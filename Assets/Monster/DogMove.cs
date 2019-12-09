using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : Enemy
{
    [SerializeField]
    float span = 4.0f;
    [SerializeField]
    float walkPower = 3.0f;
    Rigidbody2D rid2D;
    GameObject player;
    Animator anime;
    AudioSource aud;

    float walkTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        base.power = 3;
        player = GameObject.Find("chara");
        anime = GetComponent<Animator>();
        rid2D = GetComponent<Rigidbody2D>();
        base.hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (dis < 25)
        {
            this.anime.SetBool("Jump", false);
            if (hp <= 0)
            {
                aud.Play();
                Destroy(this.gameObject);
            }
            int key;
            int a = Random.Range(0, 3);
            walkTimer += Time.deltaTime * a;
            if (walkTimer > span)
            {
                this.anime.SetBool("Jump", true);
                walkTimer = 0;
                if (player.transform.position.x < this.transform.position.x)
                {
                    key = -1;
                }
                else
                {
                    key = 1;
                }
                transform.localScale = new Vector3(-1 * key * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1);
                rid2D.velocity = new Vector3(walkPower * key, 2, 0);
            }
        }

    }
}
