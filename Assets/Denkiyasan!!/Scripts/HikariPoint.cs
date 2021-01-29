﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikariPoint : MonoBehaviour
{
    public GameObject prefab;

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
        Vector3 offset = new Vector3(0, 0.5f, 0);

        Gizmos.color = new Color(0, 0, 1, 0.8f);
        Gizmos.DrawSphere(transform.position , 0.5f);

        //if (prefab != null)
        // Gizmos.DrawIcon(transform.position+offset, prefab.name,true);
    }
}
