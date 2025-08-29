using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _orientationTransform;



    [Header("Movement Settings")]
    [SerializeField] private float _movementspeed;


    [Header("Jump Settings")]

    [SerializeField] private KeyCode _jumpkey;

    [SerializeField] private float _jumpforce;

    [SerializeField] private float _jumpcooldown;

    [SerializeField] private bool _canjump;

    [SerializeField] private float _downforce;

    [Header("Ground Check Settings")]
    [SerializeField] private float _playerheight;
    [SerializeField] private LayerMask _groundlayer;





    private Rigidbody _PlayerRigidbody;


    private float _verticalinput, _horizantalinput;


    private Vector3 _movementDirection;

    private void Awake()
    {


        _PlayerRigidbody = GetComponent<Rigidbody>();
        _PlayerRigidbody.freezeRotation = true;


    }
    private void Update()
    {
        SetInputs();
    }
    private void FixedUpdate()
    {
        SetPlayerMovement();
        setGravity();
    }

    private void SetInputs()
    {
        _verticalinput = Input.GetAxisRaw("Vertical");
        _horizantalinput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(_jumpkey) && _canjump && IsGrounded())
        {
            //guş uçuyor
            _canjump = false;
            

            SetPlayerJumping();
            Invoke(nameof(ResetJumping), _jumpcooldown);


        }
    }
    private void SetPlayerMovement()
    {
        _movementDirection = _orientationTransform.forward * _verticalinput +
        _orientationTransform.right * _horizantalinput;

        _PlayerRigidbody.AddForce(_movementDirection.normalized * _movementspeed, ForceMode.Force);
    }
    private void SetPlayerJumping()
    {
        _PlayerRigidbody.linearVelocity = new Vector3(_PlayerRigidbody.linearVelocity.x, 0f, _PlayerRigidbody.linearVelocity.z);
        _PlayerRigidbody.AddForce(transform.up * _jumpforce, ForceMode.Impulse);
    }
    private void ResetJumping()
    {
        _canjump = true;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _playerheight * 0.5f + 0.2f, _groundlayer);
    }
    private void setGravity()
    {
        if (!IsGrounded())
        {
            _PlayerRigidbody.AddForce(Vector3.down * _downforce, ForceMode.Force);
        }
        
    }
}
