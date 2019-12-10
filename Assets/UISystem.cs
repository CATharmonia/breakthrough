using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    Text HP;
    [SerializeField]
    Text BulletP;
    [SerializeField]
    Text BulletDamage;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("chara");

    }

    // Update is called once per frame
    void Update()
    {
        HP.text=("HP : "+(int)player.GetComponent<PlayerDamage>().playerHP);
        if ((int)player.GetComponent<Player>().bulletGauge == 0)
        {
            BulletP.text = ("OVER HEAT!!!");
        }
        else
        {
            BulletP.text = ("Bullet Power : " + (int)player.GetComponent<Player>().bulletGauge);
        }
        BulletDamage.text = ("Bullet Damage : " + bullet.GetComponent<Bullet>().bulletPower);
    }
}
