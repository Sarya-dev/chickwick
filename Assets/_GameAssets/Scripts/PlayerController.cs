using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _orientationTransform;



    [Header("Movement Settings")]
    [SerializeField] private float _movementspeed;
    [SerializeField] private KeyCode _movementkey;


    [Header("Jump Settings")]

    [SerializeField] private KeyCode _jumpkey;

    [SerializeField] private float _jumpforce;

    [SerializeField] private float _jumpcooldown;

    [SerializeField] private bool _canjump;

    [SerializeField] private float _downforce;

    [Header("Sliding Settings")]
    [SerializeField] private KeyCode _slidingkey;
    [SerializeField] private float _slideMultiplier;
    [SerializeField] private float _slideDrag;

    [Header("Ground Check Settings")]
    [SerializeField] private float _playerheight;
    [SerializeField] private LayerMask _groundlayer;
    [SerializeField] private float _groundDrag;



    private bool _isSliding;

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
        SetDrag();
        LimitSpeed();
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

        if (Input.GetKeyDown(_slidingkey))
        {
            Debug.Log("Player Sliding");
            _isSliding = true;
        }
        else if (Input.GetKeyDown(_movementkey))
        {
            Debug.Log("Player moving");
            _isSliding = false;
        }
        else if (Input.GetKey(_jumpkey) && _canjump && IsGrounded())
        {
            //guş uçuyor
            _canjump = false;
            SetPlayerJumping();
            Invoke(nameof(ResetJumping), _jumpcooldown);


        }
    }
    private void SetDrag()
    {
        if (_isSliding)
        {
            _PlayerRigidbody.linearDamping = _slideDrag;
        }
        else
        {
            _PlayerRigidbody.linearDamping = _groundDrag;
        }
    }
    private void LimitSpeed()
    {
        Vector3 flatvelocity = new Vector3(_PlayerRigidbody.linearVelocity.x, 0f, _PlayerRigidbody.linearVelocity.z);
        if (flatvelocity.magnitude > _movementspeed)
        {
            Vector3 limitedvelocity = flatvelocity.normalized *_movementspeed;
            _PlayerRigidbody.linearVelocity = new Vector3(limitedvelocity.x, _PlayerRigidbody.linearVelocity.y, limitedvelocity.z);
        }
    }
    private void SetPlayerMovement()
    {
        _movementDirection = _orientationTransform.forward * _verticalinput +
        _orientationTransform.right * _horizantalinput;
        if (_isSliding)
        {
            _PlayerRigidbody.AddForce(_movementDirection.normalized * _movementspeed * _slideMultiplier, ForceMode.Force);
        }
        else { _PlayerRigidbody.AddForce(_movementDirection.normalized * _movementspeed, ForceMode.Force); }
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
