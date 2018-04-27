using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{

    Transform m_transform, m_camera; //人物自己以及相机的对象
    CharacterController controller; //Charactor Controller组件
    private Animator m_Animator;    //动画控制器
    public float MoveSpeed = 20.0f; //移动的速度
    public float JumpForce = 2.0f;  //跳跃能量
    // Use this for initialization
    void Start()
    {
        m_transform = this.transform; //尽量不要再update里获取this.transform，而是这样保存起来，这样能节约性能
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").transform; //
        controller = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) ||
            (Input.GetKey(KeyCode.D)))
        {
            float speed = MoveSpeed;
            if (!(Input.GetKey(KeyCode.LeftShift)))//走
            {
                 m_Animator.SetFloat("Speed_f", 0.26f);
            }else if ((Input.GetKey(KeyCode.LeftShift)))//跑
            {
                m_Animator.SetFloat("Speed_f", 0.51f);
                speed = speed * 3;
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                //根据主相机的朝向决定人物的移动方向，下同
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 180f, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 270f, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                controller.transform.eulerAngles = new Vector3(0, m_camera.transform.eulerAngles.y + 90f, 0);
            }

            controller.Move(m_transform.forward * Time.deltaTime * speed);
        }
        else
            //静止状态
            m_Animator.SetFloat("Speed_f", 0);

        if (Input.GetKey(KeyCode.Space))//跳
        {
            transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed* JumpForce);

        }

        if (!controller.isGrounded)
        {
            //模拟简单重力，每秒下降10
            controller.Move(new Vector3(0, -10f * Time.deltaTime, 0));
        }



    }
}