using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : Enemy
{
    [SerializeField]
    float flyPower = 3.0f;
    Rigidbody2D rid2d;
    public GameObject player;
    int key;
    // Start is called before the first frame update
    void Start()
    {
        base.hp = 15;
        rid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        if (player.transform.position.x < this.transform.position.x)
        {
            key = -1;
        }
        else
        {
            key = 1;
        }

        transform.localScale = new Vector3(-1 * key * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1);
        rid2d.AddForce(new Vector2(flyPower * key, 0));
    }
}
