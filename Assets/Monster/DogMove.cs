using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    [SerializeField]
    float span = 4.0f;
    [SerializeField]
    float walkPower = 3.0f;
    Rigidbody2D rid2D;
    public GameObject player;
    int hp = 10;

    float walkTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        rid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        int key;
        walkTimer += Time.deltaTime;
        if (walkTimer > span)
        {
            walkTimer = 0;
            if (player.transform.position.x < this.transform.position.x)
            {
                key = -1;
            }
            else
            {
                key = 1;
            }

            rid2D.velocity= new Vector3(walkPower*key, 2, 0);
        }
    }
    public void EnemyDamage(int power)
    {
        hp -= power;
    }
}
