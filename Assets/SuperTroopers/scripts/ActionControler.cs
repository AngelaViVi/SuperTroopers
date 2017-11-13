using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionControler : MonoBehaviour
{
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed_f", 0);//不要一上来就跑
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jump()
    {
        anim.SetBool("Jump_b", true);
    }
    public void JumpEnd()
    {
        anim.SetBool("Jump_b", false);
    }
    public void Move(Vector2 power)
    {
        float Switch = Mathf.Sqrt(power.x * power.x + power.y * power.y);
        anim.SetFloat("Speed_f", Switch);
    }

    public void MoveStop()
    {
        anim.SetFloat("Speed_f", 0);
    }

    public void ChangeViewPoint()
    {
        //ETCJoystick ETCJ = ETCJoystick
    }
}
