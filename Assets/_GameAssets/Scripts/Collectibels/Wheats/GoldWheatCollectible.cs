using UnityEngine;

public class GoldWheatCollectible : MonoBehaviour, ICollectibles 
{
    [SerializeField] WheatDesignSO _wheatDesignSO;
    [SerializeField] PlayerController _playerController;
   

    public void Collect()
    {
        _playerController.SetMovementSpeed(_wheatDesignSO.IncrreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);
        Destroy(this.gameObject);
    }
}
