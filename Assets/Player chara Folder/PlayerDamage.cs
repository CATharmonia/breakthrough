using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int playerHP = 20;
    [SerializeField]
    float mutekiTime = 2.0f;
    float timer = 0;

    bool muteki = false;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (muteki == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f, 1f, 1f, level);
            timer += Time.deltaTime;
            if (timer > mutekiTime)
            {
                muteki = false;
                renderer.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster" && muteki == false)
        {
            muteki = true;
            timer = 0;
            Damage(collision.gameObject.GetComponent<Enemy>().power);
            Debug.Log("aaa");
        }
    }
    public void Damage(int power)
    {
        playerHP -= power;
    }
}
