using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttack : MonoBehaviour
{
    [SerializeField]
    float attackSpan = 2.0f;
    float timer = 0;
    [SerializeField]
    GameObject bullet;
    GameObject player;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("chara");
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (dis < 25)
        {
            timer += Time.deltaTime;
            if (timer > attackSpan)
            {
                pos = this.transform.position;
                Instantiate(bullet, pos, Quaternion.identity);
                timer = 0;
            }
        }
    }
}