using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    [SerializeField]
    float sp = 2.0f;
    float timer = 0;
    [SerializeField]
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        base.hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(sp < timer)
        {
            Vector3 pos = this.transform.position;
            Instantiate(enemy, pos, Quaternion.identity);
            timer = 0;
        }
        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
