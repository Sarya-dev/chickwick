using UnityEngine;

public class RottenWheatCollectible : MonoBehaviour, ICollectibles
{
    [SerializeField] WheatDesignSO _wheatDesignSO;
     [SerializeField] PlayerController _playerController;


    public void Collect()
    {
        _playerController.SetMovementSpeed(_wheatDesignSO.IncrreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);
        Destroy(this.gameObject);
    }
}
