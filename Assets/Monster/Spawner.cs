using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    [SerializeField]
    float sp = 2.0f;
    float timer = 25;
    [SerializeField]
    GameObject enemy;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        base.hp = 10;
        player = GameObject.Find("chara");
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (dis < 25)
        {
            timer += Time.deltaTime;
            if (sp < timer)
            {
                Vector3 pos = this.transform.position;
                Instantiate(enemy, pos, Quaternion.identity);
                timer = 0;
            }
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
