using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour, ICollectibles 
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] float _movementspeedIncrease;
    [SerializeField] float _resetduration;

    public void Collect()
    {
        _playerController.SetMovementSpeed(_movementspeedIncrease, _resetduration);
        Destroy(this.gameObject);
    }
}
