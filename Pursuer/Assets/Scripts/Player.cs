using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private const string HorizontalMove = "Horizontal"; 
    private const string VerticalMove = "Vertical"; 

    [SerializeField] private float _speed = 3;
    [SerializeField] private float _speedJump = 5;
    [SerializeField] private float _gravity = 20;

    private Vector3 _moveDirection = Vector3.zero;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputPlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_characterController.isGrounded)
        {
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _speed;

            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = _speedJump;
            }

        }

        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirection);
    }

    private void InputPlayer()
    {
        _moveDirection = new Vector3(Input.GetAxis(HorizontalMove), 0, Input.GetAxis("Vertical"));
    }
}
