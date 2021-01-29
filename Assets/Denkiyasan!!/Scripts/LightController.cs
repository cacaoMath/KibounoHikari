using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // ゲームの明るさを制御するクラス

    const float LightMaxGaze = 110;

    public float rotateSpeed = 5f;
    public float getRotateSpeed = 15f;
    //初期の角度
    public GameObject player;
    private int lightGaze;
    private bool blackOut = false;
    private Vector3 rot = new Vector3(90f,-30f,0f);
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        //transform.localRotation = Quaternion.Euler(rot);

        float rotX = transform.localEulerAngles.x;

        transform.localEulerAngles = new Vector3(rotX, transform.localEulerAngles.y, transform.localEulerAngles.z);

    }

    // Update is called once per frame
    void Update()
    {
       
        //Debug.Log(transform.localEulerAngles.x);

        //ゲーム内の照明を動かすことで，画面の明るさを調整する回転角は手動で設定
        if (transform.localEulerAngles.x +360 <= 450)
        {
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            lightGaze = (int)(((transform.localEulerAngles.x + 20f) / LightMaxGaze)*100);
        }
        else if (transform.localEulerAngles.x <= 360 && transform.localEulerAngles.x > 340)
        {
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            lightGaze = (int)(((transform.localEulerAngles.x -340f) / LightMaxGaze)*100);
        }
        else if(lightGaze == 0)
        {
            blackOut = true;
        }

        //プレーヤーが"ヒカリ"をとるとゲーム照明を明るくする．
        if (playerController.IsGetHikari() && (transform.localEulerAngles.x < 90 - getRotateSpeed || (transform.localEulerAngles.x <= 360 && transform.localEulerAngles.x > 340)))
        {

            transform.Rotate(-Vector3.right * getRotateSpeed);
            //Debug.Log(transform.localEulerAngles.x);
            playerController.resetGetHikari();
        }
         else if (playerController.IsGetHikari() && (transform.localEulerAngles.x < 90 && transform.localEulerAngles.x > 90 - getRotateSpeed))
         {
            transform.localEulerAngles = new Vector3(90f, transform.localEulerAngles.y, transform.localEulerAngles.z);
            playerController.resetGetHikari();
        }

        //Debug.Log(lightGaze);
        
    }

    public int GetLightGaze()
    {
        return lightGaze;
    }

    public bool IsBlackOut()
    {
        return blackOut;
    }
}
