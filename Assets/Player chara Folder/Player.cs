using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public float bulletGauge = 100;
    float bulletGaugeMax;
    [SerializeField]
    float bulletRecovery = 10;
    [SerializeField]
    float bulletCost = 5;
    [SerializeField]
    float los = 3;
    [SerializeField]
    GameObject Bullet;
    Animator animator;
    static int key = 1;
    bool canShot=true;
    float losTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        bulletGaugeMax = bulletGauge;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShot == true)
        {
            bulletGauge += bulletRecovery * Time.deltaTime;
        }
        if (bulletGauge > bulletGaugeMax)
        {
            bulletGauge = bulletGaugeMax;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }
        if (Input.GetMouseButtonDown(0) && canShot == true)
        {
            bulletGauge -= bulletCost;
            Vector3 pos = transform.position;
            if (animator.GetInteger("Status") != 3)
            {
                pos.x += (1.5f * key);
                pos.y += 3;
            }
            else
            {
                pos.x += 1.4f * key;
                pos.y += 1.9f;
            }
            GameObject clone = Instantiate(Bullet, pos, Quaternion.identity);
            // Rigidbody2D に移動量を加算する
            if (Input.GetKey(KeyCode.DownArrow))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1 * key, 0, 0) * 10.0f;
            }
            else
            {
                float a = Random.Range(-0.5f, 0.5f);
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1 * key, a, 0) * 10.0f;
            }
        }
        if (bulletGauge < 0)
        {
            canShot = false;
            bulletGaugeMax *= 0.8f;
            bulletGauge = 0;
        }
        if (canShot == false)
        {
            losTime += Time.deltaTime;
        }
        if (losTime > los)
        {
            bulletGauge = bulletGaugeMax / 2;
            losTime = 0;
            canShot = true;
        }
    }
    public static int GetRot()
    {
        return key;
    }
}
