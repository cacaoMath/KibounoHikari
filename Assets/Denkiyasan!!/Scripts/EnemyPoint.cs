﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public GameObject prefab;

    //敵出現の座標を生成

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(
            prefab,
            Vector3.zero,
            Quaternion.identity   
            );

        go.transform.SetParent(transform, false);
    }

    private void OnDrawGizmos()
    {
        Vector3 offset = new Vector3(0, 0.2f, 0);

        Gizmos.color = new Color(1,1,0,0.5f);
        Gizmos.DrawSphere(transform.position + offset, 0.5f);

        //if (prefab != null)
           // Gizmos.DrawIcon(transform.position+offset, prefab.name,true);
    }
}
