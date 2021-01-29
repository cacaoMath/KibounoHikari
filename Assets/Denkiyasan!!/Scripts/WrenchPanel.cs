using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchPanel : MonoBehaviour
{
    //プレイヤーの体力表示部分の制御
    public GameObject[] icons;
    public void UpdateWrench(int wrench)
    {
        for (int i = 0;i < icons.Length;i++)
        {
            if (i < wrench) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
