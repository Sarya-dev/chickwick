using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] float _movementspeedIncrease;
    [SerializeField] float _resetduration;

    public void collect()
    {
        _playerController.SetMovementSpeed(_movementspeedIncrease, _resetduration);
        Destroy(this.gameObject);
    }
}
