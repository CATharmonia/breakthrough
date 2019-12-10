using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    float bulletlife = 2.0f;
    float life = 0;
    public int bulletPower = 2;
    bool isCurve = false;
    [SerializeField]
    GameObject effect;
    public AudioClip Bsound;
    AudioSource audioSource;
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(Bsound);
    }
    void Update()
    {
        life +=Time.deltaTime;
        if (life > 0.4f&&isCurve==false)
        {
            Curve();
            isCurve = true;
        }
        if(life > bulletlife)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Instantiate(effect, this.transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Enemy>().EnemyDamage(bulletPower);
            Destroy(this.gameObject);
        }

    }
    void Curve()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - this.transform.position), new Vector3(1, 1, 0)).normalized;
        this.GetComponent<Rigidbody2D>().velocity = shotForward * 10.0f;
    }
}