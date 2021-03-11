using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    private Rigidbody _player;

    private float _jumpStreanght = 40;

    private bool _isGround;

    private void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _player.AddForce(_player.transform.up * _jumpStreanght,ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            _isGround = true;
            Debug.Log(_isGround);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isGround = false;
        Debug.Log(_isGround);
    }
}
