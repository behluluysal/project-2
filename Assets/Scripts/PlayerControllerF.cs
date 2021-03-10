using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerF : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _player;
    void Start()
    {
        
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
}
