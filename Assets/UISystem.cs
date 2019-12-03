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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HP.text=("HP : "+(int)player.GetComponent<PlayerDamage>().playerHP);
        BulletP.text = ("Bullet Power : " + (int)player.GetComponent<Player>().bulletGauge);
    }
}
