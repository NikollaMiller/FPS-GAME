using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    private CharacterController _plController;

    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundMask;

    private float speed = 20f;
    private float gravity = -60f;
    private float _groundDistance = 0.5f;
    private float _jumpHeight = 10f;

    private bool isGrounded;

    private Vector3 velocity;

    private void Start()
    {
        _plController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(_groundChecker.position,_groundDistance,_groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }        

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 40f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 20f;
        }

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        _plController.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * gravity );
        }

        velocity.y += gravity * Time.deltaTime;

        _plController.Move(velocity * Time.deltaTime);
    }

}
