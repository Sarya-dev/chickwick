using UnityEngine;

public class HolyWheatCollectible : MonoBehaviour, ICollectibles
{
    [SerializeField] WheatDesignSO _wheatDesignSO;
     [SerializeField] PlayerController _playerController;
    
    

    public void Collect()
    {
        _playerController.SetJumpForce(_wheatDesignSO.IncrreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);
        Destroy(this.gameObject);
    }
}
