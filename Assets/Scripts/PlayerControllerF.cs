using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerF : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerControllerF Instance;
    [SerializeField] private GameObject _player;
    [SerializeField] private Animator _animator;
    private int direction = 1;
    void Awake()
    {
        Instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            _player.transform.position += new Vector3(2, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _player.transform.position += new Vector3(-2, 0, 0);
        }
    }

    public void rightClick()
    {
        if (_animator.GetBool("isLeft"))
        {
            if(_animator.GetFloat("speed") == 0)
                _animator.SetBool("rotate", true);
            else if (_animator.GetFloat("speed") == 1)
                _animator.SetFloat("speed", 0);
            else if (_animator.GetFloat("speed") == 2)
                _animator.SetFloat("speed", 1);
        }
        else
        {
            if (_animator.GetFloat("speed") == 0)
            {
                _animator.SetFloat("speed", 1);
            }
            else if (_animator.GetFloat("speed") == 1)
            {
                _animator.SetFloat("speed", 2);
            }
        }
        
    }

    public void leftClick()
    {
        if (!_animator.GetBool("isLeft"))
        {
            if (_animator.GetFloat("speed") == 0)
                _animator.SetBool("rotate", true);
            else if (_animator.GetFloat("speed") == 1)
                _animator.SetFloat("speed", 0);
            else if (_animator.GetFloat("speed") == 2)
                _animator.SetFloat("speed", 1);
            Debug.Log("girdi");
        }   
        else
        {
            if (_animator.GetFloat("speed") == 0)
            {
                _animator.SetFloat("speed", 1);
            }
            else if (_animator.GetFloat("speed") == 1)
            {
                _animator.SetFloat("speed", 2);
            }
        }
        
    }

    public void Attack()
    {
        if (_animator.GetFloat("speed") >= 2)
        {
            _animator.SetBool("Dash&Attack",true);
        }
        else if(_animator.GetFloat("speed") <= 1)
        {
            _animator.SetBool("attack", true);

        }
    }
}
