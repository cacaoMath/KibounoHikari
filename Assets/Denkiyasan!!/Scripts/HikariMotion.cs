using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikariMotion : MonoBehaviour
{
    //ゲーム上の黄色いやつ"ヒカリ"のアニメーション等の制御


    Collider collider;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collider.isTrigger == true)
        {
            animator.SetTrigger("Active");
        }
    }
}
