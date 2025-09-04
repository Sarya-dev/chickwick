using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour
{
     [SerializeField] PlayerController _playerController;
    [SerializeField] float _jumpForceIncrease;
    [SerializeField] float _resetduration;

    public void collect()
    {
        _playerController.SetJumpForce(_jumpForceIncrease, _resetduration);
        Destroy(this.gameObject);
    }
}
