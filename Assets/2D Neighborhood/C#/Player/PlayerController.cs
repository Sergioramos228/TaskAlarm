using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _whatIsGround;
    //[SerializeField] private ParticleSystem Dust;

    private Rigidbody2D _rigidbody;
    private float _moveInput;
    private bool _isGrounded;
    private Animator _animator;

    void Start() 
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        _moveInput = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);

        if (_moveInput == 0)
        {
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }
    }

    void Update() 
    {
        _isGrounded = Physics2D.OverlapCircle(transform.position, _checkRadius, _whatIsGround);
      
        if(_moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (_moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    
        if(_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {          
            _animator.SetTrigger("takeOff");

            _rigidbody.velocity = Vector2.up * _jumpForce;

            //CreateDust();
        }

        if(_isGrounded == true)
        {
            _animator.SetBool("isJumping", false);
        }
        else
        {
            _animator.SetBool("isJumping", true);
        }
    }

    //void CreateDust()
    //{
        //Dust.Play();
    //}
}