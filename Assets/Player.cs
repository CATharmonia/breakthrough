using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    // 弾オブジェクトの移動係数（速度調整用）
    float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject clone= Instantiate(Bullet);        // 弾オブジェクトの移動量ベクトルを作成（数値情報）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
            // Rigidbody2D に移動量を加算する
            clone.GetComponent<Rigidbody2D>().velocity = shotForward * bulletSpeed;
        }
    }
}
