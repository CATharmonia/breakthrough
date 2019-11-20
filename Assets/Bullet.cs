using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class Bullet : MonoBehaviour
{
    float bulletlife = 2.0f;
    float life = 0;
    async void Start()
    {
        await Task.Delay(400);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - this.transform.position), new Vector3(1, 1, 0)).normalized;
        this.GetComponent<Rigidbody2D>().velocity = shotForward * 10.0f;
    }
    void Update()
    {
        life +=Time.deltaTime;
        if(life > bulletlife)
        {
            Destroy(gameObject);
        }
    }
}