using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    Animator animator;
    static int key = 1;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = transform.position;
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
            Instantiate(Bullet,pos, Quaternion.identity);
        }
    }
    public static int GetRot()
    {
        return key;
    }
}
