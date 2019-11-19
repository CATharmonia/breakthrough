using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    float bulletlife = 2.0f;
    float life = 0; 
    void Start()
    {
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