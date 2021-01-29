using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjPoint : MonoBehaviour
{
    //動く敵の座標計算用

    Transform obj;
    float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent <Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.localPosition.x > 0.4 || obj.localPosition.x < -0.4)
        {
            speed *= -1;
        }
        obj.localPosition += new Vector3(speed, 0, 0);
    }
}
