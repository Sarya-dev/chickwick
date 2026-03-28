using UnityEngine;

public class PlayerİnteractionController : MonoBehaviour
{
    [SerializeField] private Transform _playerVisualTransform;
    private Rigidbody _playerRigidbody;  
    private PlayerController _playerController;
    private void Awake() {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody = GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectibles>(out var Collectibles))
        {
            Collectibles.Collect();
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.TryGetComponent<IBoostable>(out var boostable))
        {
            boostable.Boost( _playerController);
        }
    }
    private void OnParticleCollision(GameObject other) {
        if(other.TryGetComponent<IDamagable>(out var damagable))
        {
            damagable.GiveDamage(_playerRigidbody, _playerVisualTransform);
        }
    }
}
