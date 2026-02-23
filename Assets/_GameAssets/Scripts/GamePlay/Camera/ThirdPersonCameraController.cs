using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _orientationTransform;
    [SerializeField] private Transform _playervisualTransform;
    [Header("Settings")]
    [SerializeField] private float _rotationspeed;

    private void Update()
    {
        if (GameManager.Instance.GetCurrentGameState() != GameState.play
        && GameManager.Instance.GetCurrentGameState() != GameState.resume )
        {
            return;

        }
        Vector3 viewdirection = _playerTransform.position - new Vector3(transform.position.x, _playerTransform.position.y, transform.position.z);

        _orientationTransform.forward = viewdirection.normalized;

        float _verticalinput = Input.GetAxisRaw("Vertical");
        float _horizontalinput = Input.GetAxisRaw("Horizontal");

        Vector3 inputDirection = _orientationTransform.forward * _verticalinput + _orientationTransform.right * _horizontalinput;

        if (inputDirection != Vector3.zero)
        {


            _playervisualTransform.forward
            = Vector3.Slerp(_playervisualTransform.forward, inputDirection.normalized, Time.deltaTime * _rotationspeed);
        }


    }
}