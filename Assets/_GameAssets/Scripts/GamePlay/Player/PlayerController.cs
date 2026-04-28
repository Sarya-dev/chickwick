using UnityEngine;
using System;

public class PlayerController : MonoBehaviour


{
    public event Action OnPLayerJumped;
    public event Action<PlayerState> OnPlayerStateChanged;

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
    [SerializeField] private float _airMultiplier;
    [SerializeField] private float _airDrag;

    [SerializeField] private float _downforce;

    [Header("Sliding Settings")]
    [SerializeField] private KeyCode _slidingkey;
    [SerializeField] private float _slideMultiplier;
    [SerializeField] private float _slideDrag;

    [Header("Ground Check Settings")]
    [SerializeField] private float _playerheight;
    [SerializeField] private LayerMask _groundlayer;
    [SerializeField] private float _groundDrag;


    private float _startingspeed, _startingjumpforce;

    private bool _isSliding;
    private StateController _StateController;

    private Rigidbody _PlayerRigidbody;


    private float _verticalinput, _horizantalinput;


    private Vector3 _movementDirection;

    private void Awake()
    {
        _StateController = GetComponent<StateController>();
        _PlayerRigidbody = GetComponent<Rigidbody>();
        _PlayerRigidbody.freezeRotation = true;
        _startingspeed = _movementspeed;
        _startingjumpforce = _jumpforce;


    }
    private void Update()
    {
        if (GameManager.Instance.GetCurrentGameState() != GameState.play
        && GameManager.Instance.GetCurrentGameState() != GameState.resume )
        {
            return;

        }
        SetInputs();
        SetStates();
        SetDrag();
        LimitSpeed();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.GetCurrentGameState() != GameState.play
        && GameManager.Instance.GetCurrentGameState() != GameState.resume )
        {
            return;

        }
        SetPlayerMovement();
        setGravity();
    }

    private void SetInputs()
    {
        _verticalinput = Input.GetAxisRaw("Vertical");
        _horizantalinput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(_slidingkey))
        {
            _isSliding = true;
        }
        else if (Input.GetKeyDown(_movementkey))
        {
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
        _PlayerRigidbody.linearDamping = _StateController.returnstate() switch
        {
            PlayerState.Move => _groundDrag,
            PlayerState.Slide => _slideDrag,
            PlayerState.Jump => _airDrag,
            _ => _PlayerRigidbody.linearDamping

        };
    }
    private void LimitSpeed()
    {
        Vector3 flatvelocity = new Vector3(_PlayerRigidbody.linearVelocity.x, 0f, _PlayerRigidbody.linearVelocity.z);
        if (flatvelocity.magnitude > _movementspeed)
        {
            Vector3 limitedvelocity = flatvelocity.normalized * _movementspeed;
            _PlayerRigidbody.linearVelocity = new Vector3(limitedvelocity.x, _PlayerRigidbody.linearVelocity.y, limitedvelocity.z);
        }
    }

    private void SetStates()
    {
        var movementeDirection = GetMovementDirection();
        var ısGrounded = IsGrounded();
        var currentState = _StateController.returnstate();
        var isSliding = IsSliding();

        var newState = currentState switch
        {
            _ when movementeDirection == Vector3.zero && ısGrounded && !isSliding => PlayerState.Idle,
            _ when movementeDirection != Vector3.zero && ısGrounded && !isSliding => PlayerState.Move,
            _ when movementeDirection != Vector3.zero && ısGrounded && isSliding => PlayerState.Slide,
            _ when movementeDirection == Vector3.zero && ısGrounded && isSliding => PlayerState.SlideIdle,
            _ when !_canjump && !ısGrounded => PlayerState.Jump,
            _ => currentState

        };
        if (newState != currentState)
        {
            _StateController.ChangeState(newState);
            OnPlayerStateChanged?.Invoke(newState);
        }

    }
    private void SetPlayerMovement()
    {
        _movementDirection = _orientationTransform.forward * _verticalinput +
        _orientationTransform.right * _horizantalinput;

        float _forcemultiplier = _StateController.returnstate() switch
        {
            PlayerState.Move => 1f,
            PlayerState.Slide => _slideMultiplier,
            PlayerState.Jump => _airMultiplier,
            _ => 1f

        };

        _PlayerRigidbody.AddForce(_movementDirection.normalized * _movementspeed * _forcemultiplier, ForceMode.Force);

    }
    private void SetPlayerJumping()
    {
        OnPLayerJumped?.Invoke();
        _PlayerRigidbody.linearVelocity = new Vector3(_PlayerRigidbody.linearVelocity.x, 0f, _PlayerRigidbody.linearVelocity.z);
        _PlayerRigidbody.AddForce(transform.up * _jumpforce, ForceMode.Impulse);

    }
    private void ResetJumping()
    {
        _canjump = true;
    }
    #region Helper functions

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
    private Vector3 GetMovementDirection()
    {
        return _movementDirection.normalized;
    }
    private bool IsSliding()
    {
        return _isSliding;
    }
    public void SetMovementSpeed(float speed, float duration)
    {
        _movementspeed += speed;
        Invoke(nameof(ResetMovementspeed), duration);
    }
    private void ResetMovementspeed()
    {
        _movementspeed = _startingspeed;
    }
    public void SetJumpForce(float force, float duration)
    {
        _jumpforce += force;
        Invoke(nameof(ResetJumpForce), duration);
    }
    private void ResetJumpForce()
    {
        _jumpforce = _startingjumpforce;
    }
    public Rigidbody GetPlayerRigidbody()
    {
        return _PlayerRigidbody;
    } 
    
    
        #endregion
}
