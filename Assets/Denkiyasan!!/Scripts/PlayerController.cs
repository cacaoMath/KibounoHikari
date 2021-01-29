using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーの操作，動きを制御するクラス

    const int MaxX = 2;
    const int MinX = -2;
    const float Xwidth = 1.0f;
    const int MaxJump = 2;
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;
    const float InvicibleDuration = 1.0f;

    CharacterController controller;
    Animator animator;
    

    Vector3 moveDirection = Vector3.zero;
    int targetX;
    int JumpCount = 0;
    int life = DefaultLife;
    float invincibleTime = 0.0f;
    float recoverTime = 0.0f;
    bool getHikari = false;
    int hikariScore = 0;

    GameObject[] existHikari = new GameObject[2];//光をつなぐオブジェクト保存 0= last,1=now

    public LightController lightController;
    public AudioSource[] se = new AudioSource[3];//0-damage 1-getHikari 2-jump
    public Material lightOn;
    //public Collider enemyCollider;
    public float gravity;
    public float speedZ;
    public float speedX;
    public float jumpSpeed;
    public float acceleratiionZ;

    public GameObject[] GetTouchedHikari()
    {
        return existHikari;
    }

    void HikariLength()//光をつなげた長さ計算
    {
        if (existHikari[0] != null && existHikari[1] != null)
        {
            hikariScore += (int)(existHikari[1].transform.position.z - existHikari[0].transform.position.z);
        }
    }

    public int HikariScore()//光をつなげた長さ
    {
        return hikariScore;
    }

    public bool IsGetHikari()
    {
        return getHikari;
    }

    public void resetGetHikari()
    {
        getHikari = false;
    }

    public int Life()
    {
        return life;
    }

    public bool IsInvicible()
    {
        return invincibleTime > 0.0f;
    }

    public bool IsStan()//敵にぶつかると止まる
    {
        return recoverTime > 0.0f || life <= 0 || lightController.IsBlackOut();//暗くなっても止まる
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();//作れたら
        //existHikari[0] = existHikari[1] =  firstHikari;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left")) MoveToLeft();
        if (Input.GetKeyDown("right")) MoveToRight();
        if (Input.GetKeyDown("space")) Jump();


        if (IsStan())
        {
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            recoverTime -= Time.deltaTime;

        }
        else
        {
            if (IsInvicible())
            {
                invincibleTime -= Time.deltaTime;
            }
            else
            {

            }

            //自動で前に進んでいく
            moveDirection.z = speedZ;

            float ratioX = (targetX * Xwidth - transform.position.x) / Xwidth;
            moveDirection.x = ratioX * speedX;
        }

        //自由落下計算
        moveDirection.y -= gravity * Time.deltaTime;

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection*Time.deltaTime);

        if (controller.isGrounded) moveDirection.y = 0;
        animator.SetBool("run",moveDirection.z > 0.0f);

    }


    public void MoveToLeft()
    {
        if (IsStan()) return;
        if (controller.isGrounded && targetX > MinX) {
            targetX --;
        }
    }

    public void MoveToRight()
    {
        if (IsStan()) return;
        if (controller.isGrounded && targetX < MaxX)
        {
            targetX ++;
        }
    }

    public void Jump()
    {
        if (IsStan()) return;
        if (controller.isGrounded)
        {
            JumpCount = 0;
            moveDirection.y = jumpSpeed;
            animator.SetTrigger("jump");
            se[2].Play();
            JumpCount++;

        }else if (!controller.isGrounded && JumpCount < MaxJump)
        {
            moveDirection.y = jumpSpeed;
            animator.SetTrigger("jump2");
            se[2].Play();
            JumpCount++;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStan()) return;

        if(hit.collider.tag == "Enemy" && !IsInvicible())
        {
            life--;
            recoverTime = StunDuration;
            invincibleTime = InvicibleDuration;
            animator.SetTrigger("damage");
            se[0].Play();
            Destroy(hit.gameObject);
        }else if(hit.collider.tag == "Enemy" && IsInvicible())
        {
            hit.collider.isTrigger = true;
        }

        if(hit.collider.tag == "Hikari")
        {
            if(existHikari[1] != null) existHikari[0] = existHikari[1];

            existHikari[1] = hit.gameObject;
            HikariLength();
            hit.gameObject.GetComponent<Renderer>().material = lightOn; 
            hit.collider.isTrigger = true;
            se[1].Play();
            getHikari = true;
            //Destroy(hit.gameObject);
        }
    }


}
