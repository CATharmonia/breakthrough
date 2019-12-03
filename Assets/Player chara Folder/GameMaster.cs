using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    GameObject player, boss;
    PlayerDamage HPsys;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("chara");
        boss = GameObject.Find("Boss");
        HPsys = player.GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HPsys.playerHP <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
        if (boss.GetComponent<Enemy>().hp <= 0)
        {
            SceneManager.LoadScene("Gameclear");
        }
    }
}
