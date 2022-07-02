using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float rotateSpeed;
    public float speed;
    public float jumpPower;
    public float jumpSmoothness;

    private float gravityForce;
    private float timeToNextJump;

    private Vector3 moveVector;
    private CharacterController ch_controller;

    private ArcherAnimation _animation_cs;
    private PlayerInput _playerInput_cs;

    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        _animation_cs = GetComponent<ArcherAnimation>();
        _playerInput_cs = GetComponent<PlayerInput>();
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (_playerInput_cs.GetHorizontal() != 0 || _playerInput_cs.GetVertical() != 0)
        {
            _animation_cs.SetBool("Run", true);
        }
        else
        {
            _animation_cs.SetBool("Run", false);
        }
        transform.Rotate(0, _playerInput_cs.GetHorizontal() * rotateSpeed, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * _playerInput_cs.GetVertical();
        controller.SimpleMove(forward * curSpeed);
        GamingGravity();
    }
    
    private void GamingGravity()
    {
        if (ch_controller.isGrounded)
        {
            gravityForce = -1f;

            if (_playerInput_cs.GetButtonJump())
            {
                StartCoroutine(Jump());
            }
        }
        else
        {
            gravityForce -= 20f * Time.deltaTime;
        }
    }

    private IEnumerator Jump()
    {
        if (timeToNextJump < Time.time || timeToNextJump == 0)
        {
            _animation_cs.SetTrigger("Jump");
            yield return new WaitForSeconds(0.25f);

            for (int i = 0; i < jumpSmoothness; i++)
            {
                yield return new WaitForEndOfFrame();
                transform.Translate(Vector3.up * (jumpPower / jumpSmoothness) * Time.deltaTime);
            }

            timeToNextJump = Time.time + 2;
        }
    }
}
