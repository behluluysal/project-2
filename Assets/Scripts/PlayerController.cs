using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void TurnLeft() 
    {
        if (_animator.GetBool("isPunching"))
        {
            _animator.SetBool("isPunching", false);
        }
        _animator.SetBool("isLeft", true);
        _animator.SetBool("isRight", false);
        transform.Rotate(0, 180, 0);
    }

    public void TurnRight() 
    {
        if (_animator.GetBool("isPunching"))
        {
            _animator.SetBool("isPunching", false);
        }
        _animator.SetBool("isLeft", false);
        _animator.SetBool("isRight", true);
        transform.Rotate(0, 180, 0);
    }

    public void Attack() 
    {
        if (_animator.GetBool("isPunching"))
        {
            _animator.SetBool("isPunching", false);
        }
        else
        {
            _animator.SetBool("isPunching", true);
        }
        _animator.SetBool("isLeft", false);
        _animator.SetBool("isRight", false);
    }
}
