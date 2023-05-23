using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    private Animator _anim;
    [SerializeField]
    private bool isPlayerOne = false;
    [SerializeField]
    private bool isPlayerTwo = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOne){

            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _anim.SetBool("turn_Left", true);
                _anim.SetBool("turn_Right",false);

            }else if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _anim.SetBool("turn_Left", false);
                _anim.SetBool("turn_Right", false);
            }

            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                _anim.SetBool("turn_Left", false);
                _anim.SetBool("turn_Right", true);

            }else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                _anim.SetBool("turn_Left", false);
                _anim.SetBool("turn_Right", false);
            }

        }else if(isPlayerTwo){

            if(Input.GetKeyDown(KeyCode.A))
            {
                _anim.SetBool("turn_Left", true);
                _anim.SetBool("turn_Right",false);

            }else if(Input.GetKeyUp(KeyCode.A))
            {
                _anim.SetBool("turn_Left", false);
                _anim.SetBool("turn_Right", false);
            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                _anim.SetBool("turn_Left", false);
                _anim.SetBool("turn_Right", true);

            }else if (Input.GetKeyUp(KeyCode.D))
            {
                _anim.SetBool("turn_Left", false);
                _anim.SetBool("turn_Right", false);
            }

        }
       

    }
}
