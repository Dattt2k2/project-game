using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : Singleton<GameManage>
{

    FlappyBird m_player;
    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        base.Start();

        if(!PlayerPrefs.HasKey(PrefConst.COIN_KEY))
        {
            Pref.Coins = 10000;
        }

        //ActivePlayer();

        GUIManage.Ins.UpdateCoin();
    }

    /*public void ActivePlayer()
    {
        if (m_player)
        {
            Destroy(m_player.gameObject);
        }

        var newPlayer = ShopManage.Ins.items[Pref.CurPlayerId].playerPb;

        if (newPlayer)
        {
            m_player = Instantiate(newPlayer, Vector3.zero, Quaternion.identity);
        }
    }*/
}
