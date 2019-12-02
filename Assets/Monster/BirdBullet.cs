﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBullet : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    int key;
    [SerializeField]
    float bulletLife = 3.0f;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
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
        Vector3 playerpos = player.transform.position;
        Vector3 shot = Vector3.Scale((playerpos - this.transform.position), new Vector3(1, 1, 0)).normalized;
        this.GetComponent<Rigidbody2D>().velocity = shot * 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bulletLife)
        {
            Destroy(this.gameObject);
        }
    }
}
