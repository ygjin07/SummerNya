using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float move_speed = 5f;
    public float jump_speed = 0.2f;
    public float jump_accell = 0.01f;
    public float dive_pos = -3.0f;
    public float dive_speed = 0.5f;
    public float dive_jump_speed = 0.2f;
    public float dive_jump_accell = 0.01f;
    public RuntimeAnimatorController[] Anis;
    public AudioSource DiveSound;
    public GameObject turtle;

    Animator Ani;
    float dive_inout_speed = 20f;
    float y = 0.0f;
    float x;
    float gravity = 0.0f;
    int jump_state = 0;
    int dive_state = 0;
    float y_base;

    void Start()
    {
        Ani = this.GetComponent<Animator>();
        y_base = this.transform.position.y;
        y = y_base;
        x = this.transform.position.x;
    }
    void Update()
    {
        JumpProcess();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DoJump();
        }
        DiveProcess();
        if(Input.GetKey(KeyCode.DownArrow))
        {
            DoDive();
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            x = Mathf.Clamp(x + move_speed * Time.deltaTime * GameManager.GM.AddSpeed * GameManager.GM.stop_move, -7.5f, 7.5f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = Mathf.Clamp(x - move_speed * Time.deltaTime * GameManager.GM.AddSpeed * GameManager.GM.stop_move, -7.5f, 7.5f);
        }

        Vector3 pos = this.transform.position;
        pos.y = y;
        pos.x = x;
        gameObject.transform.position = pos;
    }

    public void CheckJumpTurtle()
    {
        if (jump_state != 0 && GameManager.GM.Phase == 1)
        {
            turtle.SetActive(true);
            turtle.transform.position = new Vector3(this.transform.position.x, -0.9f, 0);
        }
        else
        {
            turtle.SetActive(false);
        }
    }

    public void SetCatSprite()
    {
        Ani.runtimeAnimatorController = Anis[GameManager.GM.Phase];
        if (jump_state == 0 && dive_state == 0)
        {
            Ani.SetTrigger("ToIdle");
        }
        else if(jump_state != 0)
        {
            Ani.SetTrigger("ToJump");
        }
        else if(dive_state != 0)
        {
            Ani.SetTrigger("ToDive");
        }
    }

    public int GetDiveState()
    {
        return dive_state;
    }

    void DoJump()
    {
        if (jump_state == 0 && dive_state == 0)
        {
            jump_state = 1;
            Ani.SetTrigger("ToJump");
            if (GameManager.GM.Phase == 1)
            {
                turtle.SetActive(true);
                turtle.transform.position = new Vector3(this.transform.position.x, -0.9f, 0);
            }
            gravity = jump_speed;
        }
        else if(dive_state !=0)
        {
            dive_state = 2;
            gravity = dive_jump_speed;
        }
    }
    void JumpProcess()
    {
        switch (jump_state)
        {
            //case 0: //정지
            //    {
            //        if (y > y_base)
            //        {
            //            if (y >= jump_accell)
            //            {
            //                y -= gravity;
            //            }
            //            else
            //            {
            //                y = y_base;
            //            }
            //        }
            //        break;
            //    }
            case 1: // 점프중
                {
                    y += gravity * Time.deltaTime * GameManager.GM.stop_move;
                    if (gravity <= 0.0f)
                    {
                        jump_state = 2;
                    }
                    else
                    {
                        gravity -= jump_accell * Time.deltaTime * GameManager.GM.stop_move;
                    }
                    break;
                }

            case 2: // 하락중
                {
                    y -= gravity * Time.deltaTime * GameManager.GM.stop_move;
                    if (y > y_base)
                    {
                        gravity += jump_accell * Time.deltaTime * GameManager.GM.stop_move;
                    }
                    else
                    {
                        jump_state = 0;
                        Ani.SetTrigger("ToIdle");
                        if (GameManager.GM.Phase == 1)
                        {
                            turtle.SetActive(false);
                        }
                        y = y_base;
                    }
                    break;
                }
        }
    }

    void DoDive()
    {
        if (jump_state == 0 && dive_state == 0)
        {
            DiveSound.Play();
            dive_state = 3;
            Ani.SetTrigger("ToDive");
        }
        else if(dive_state == 1)
        {
            y = Mathf.Clamp(y - dive_speed * Time.deltaTime * GameManager.GM.AddSpeed * GameManager.GM.stop_move, -7.5f, -2f); 
        }
    }

    void DiveProcess()
    {
        switch(dive_state)
        {
            case 2: // 점프중
                {
                    y += gravity * Time.deltaTime * GameManager.GM.stop_move;
                    if (gravity <= 0.0f)
                    {
                        dive_state = 1;
                    }
                    else if(y >= -2.5f)
                    {
                        DiveSound.Play();
                        dive_state = 4;
                    }
                    else
                    {
                        gravity -= dive_jump_accell * Time.deltaTime * GameManager.GM.stop_move;
                    }
                    break;
                }
            case 3: // 하락중
                {
                    y -= dive_inout_speed * Time.deltaTime * GameManager.GM.stop_move;
                    if (y <= dive_pos)
                    {
                        y = dive_pos;
                        dive_state = 1;
                    }
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, y / 2.5f * 4.5f, -10f);
                    break;
                }
            case 4: // 상승중
                {
                    y += dive_inout_speed * Time.deltaTime * GameManager.GM.stop_move;
                    if (y >= y_base)
                    {
                        y = y_base;
                        dive_state = 0;
                        Ani.SetTrigger("ToIdle");
                    }
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, y / 2.5f * 4.5f, -10f);
                    break;
                }
        }
    }
}
