using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image[] _playerHealthImages;
    [Header("Sprites")]
    [SerializeField] Sprite _playerHealthySprite;
    [SerializeField] Sprite _playerUnhealthySprite;

    private RectTransform[] _playerHealthTransforms;
    [Header("Settings")]
    [SerializeField] private float _scaleDuration;

    private void Awake()
    {
        _playerHealthTransforms = new RectTransform[_playerHealthImages.Length];
        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            _playerHealthTransforms[i] = _playerHealthImages[i].GetComponent<RectTransform>();
        }
    }
    //for Testing
    private void Update() {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AnimateDamage();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AnimateDamageForAll();
        }
    }
    public void AnimateDamage()
    {
        for (int i = 0; i < _playerHealthImages.Length; i++)
        {
            if (_playerHealthImages[i].sprite == _playerHealthySprite)
            {
                AnimateDamageSprite(_playerHealthImages[i], _playerHealthTransforms[i]);
                break;
            }
        }
    }
    public void AnimateDamageForAll()
    {
        for(int i=0; i < _playerHealthImages.Length; i++)
        {
            
                AnimateDamageSprite(_playerHealthImages[i], _playerHealthTransforms[i]);
            
        }
    }
    
    private void AnimateDamageSprite(Image activeImage, RectTransform activeImageTransform)
    {
        activeImageTransform.DOScale(0f, _scaleDuration).SetEase(Ease.InBack).OnComplete(() =>
        {
            activeImage.sprite = _playerUnhealthySprite;
            activeImageTransform.DOScale(1f, _scaleDuration).SetEase(Ease.OutBack);
        });
    }
    
}
