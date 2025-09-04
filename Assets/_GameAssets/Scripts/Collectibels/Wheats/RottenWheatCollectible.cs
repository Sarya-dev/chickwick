using UnityEngine;

public class RottenWheatCollectible : MonoBehaviour, ICollectibles
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     [SerializeField] PlayerController _playerController;
    [SerializeField] float _movementspeedDecrease;
    [SerializeField] float _resetduration;

    public void Collect()
    {
        _playerController.SetMovementSpeed(_movementspeedDecrease, _resetduration);
        Destroy(this.gameObject);
    }
}
