using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour, ICollectibles
{
     [SerializeField] PlayerController _playerController;
    [SerializeField] float _jumpForceIncrease;
    [SerializeField] float _resetduration;

    public void Collect()
    {
        _playerController.SetJumpForce(_jumpForceIncrease, _resetduration);
        Destroy(this.gameObject);
    }
}
