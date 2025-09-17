using UnityEngine;

public class PlayerİnteractionController : MonoBehaviour
{
    private PlayerController _playerController;
    private void Awake() {
        _playerController = GetComponent<PlayerController>();
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
}
