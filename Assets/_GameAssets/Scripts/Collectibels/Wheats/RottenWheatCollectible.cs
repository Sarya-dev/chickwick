using UnityEngine;
using UnityEngine.UI;

public class RottenWheatCollectible : MonoBehaviour, ICollectibles
{
    [SerializeField] WheatDesignSO _wheatDesignSO;
     [SerializeField] PlayerController _playerController;

  [SerializeField] private PlayerStateUI  _playerStateUI;
    private RectTransform _playerBoosterTransform;
    private Image _playerBoosterImage;

    private void Awake()
    {
        _playerBoosterTransform = _playerStateUI.GetBoosterSlowTransform;
        _playerBoosterImage = _playerBoosterTransform.GetComponent<Image>();
    }
    public void Collect()
    {
        _playerController.SetMovementSpeed(_wheatDesignSO.IncrreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);

        _playerStateUI.PlayerBoosterUIAnimations(_playerBoosterTransform, _playerBoosterImage,
         _playerStateUI.GetRottenBoosterWheatImage,_wheatDesignSO.ActiveSprite, _wheatDesignSO.PassiveSprite,
         _wheatDesignSO.ActiveWheatSprite, _wheatDesignSO.PassiveWheatSprite,_wheatDesignSO.ResetBoostDuration);

        Destroy(this.gameObject);
    }
}
