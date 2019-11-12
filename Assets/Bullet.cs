﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    // 弾オブジェクト（Inspectorでオブジェクトを指定）
    [SerializeField] // Inspectorで操作できるように属性を追加します
    private GameObject bullet;
    // 弾オブジェクトのRigidbody2Dの入れ物
    private Rigidbody2D rb2d;

    float bulletlife = 2.0f;
    float life = 0;
    void Start()
    {
        // オブジェクトのRigidbody2Dを取得
        rb2d = GetComponent<Rigidbody2D>();
        // 弾オブジェクトの移動係数を初期化

    }
    void Update()
    {
        // 弾オブジェクトの移動関数
        BulletMove();
        life +=Time.deltaTime;
        if(life > bulletlife)
        {
            Destroy(gameObject);
        }

    }
    // 弾オブジェクトの移動関数
    void BulletMove()
    {

    }
    // ENEMYと接触したときの関数
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ENEMYに弾が接触したら弾は消滅する
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}