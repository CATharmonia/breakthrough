using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 350.0f;
    float walkForce = 80.0f;
    float maxWalkSpeed = 5.0f;
    int ro;
    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        int ro = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.rigid2D.velocity.y == 0 && animator.GetInteger("Status")!=3)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        //左右移動
    
        int key = 0;

        if (Input.GetKey(KeyCode.RightArrow)) {
        key = 1;
            if(animator.GetInteger("Status")==2)
            ro -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            if (animator.GetInteger("Status") == 2)
                ro -= 1;
        }
        if (ro == 0) { audioSource.PlayOneShot(sound1); ro = 20; }
        
            //プレイヤの速度
            //スピード制限
            if (animator.GetInteger("Status") != 3)
        {
            if (rigid2D.velocity.x > maxWalkSpeed && key == -1 || rigid2D.velocity.x < maxWalkSpeed * -1 && key == 1 || maxWalkSpeed*-1<rigid2D.velocity.x && rigid2D.velocity.x<maxWalkSpeed)
            {
                this.rigid2D.AddForce(transform.right * key * this.walkForce);
            }
        }
        // 動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        if (rigid2D.velocity.y != 0)
        {
            animator.SetInteger("Status", 1);
        }else if (rigid2D.velocity.x != 0 && rigid2D.velocity.y == 0)
        {
            animator.SetInteger("Status", 2);
        }
        else
        {
            animator.SetInteger("Status", 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetInteger("Status", 3);
        }
        
    }
}