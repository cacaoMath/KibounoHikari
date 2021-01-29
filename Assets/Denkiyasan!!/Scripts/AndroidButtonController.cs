using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidButtonController : MonoBehaviour
{
    public GameObject androidButoon;
    // Start is called before the first frame update
    void Start()
    {
        //Androidで起動した際に補助操作ボタンを表示する．
        if(Application.platform == RuntimePlatform.Android)
        {
            androidButoon.SetActive(true);
        }
        else
        {
            androidButoon.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
