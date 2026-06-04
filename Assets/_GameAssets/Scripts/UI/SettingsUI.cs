using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MaskTransitions;
using System;

public class SettingsUI : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject _settingsPopUpObject;

    [SerializeField] private GameObject _blackBackGroundObject;
    [Header("Buttons")]
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _soundButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _mainMenuButton;
    [Header("Sprites")]
    [SerializeField] private Sprite _musicOnSprite;
    [SerializeField] private Sprite _musicOffSprite;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;
    [Header("Settings")]
    [SerializeField] private float _animationDuration;
    private Image _blackBackgroundImage;

    private bool _isMusicOn;
    private bool _isSoundOn; 

    private void Awake()
    {
        _blackBackgroundImage = _blackBackGroundObject.GetComponent<Image>();
        _settingsPopUpObject.transform.localScale = Vector3.zero;
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _mainMenuButton.onClick.AddListener(() =>
        {
        AudioManager.Instance.Play(SoundType.TransitionSound);
 
            TransitionManager.Instance.LoadLevel(Consts.SceneNames.MENU_SCENE);
           
        });
        _musicButton.onClick.AddListener(OnMusicButtonClicked);
        _soundButton.onClick.AddListener(OnSoundButtonClicked);

    }

    private void OnMusicButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        _isMusicOn = !_isMusicOn;
        _musicButton.image.sprite = _isMusicOn ? _musicOnSprite : _musicOffSprite;
        AudioManager.Instance.SetSoundEffectsMute(!_isMusicOn);
    }

    private void OnSoundButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        _isSoundOn = !_isSoundOn;
        _soundButton.image.sprite = _isSoundOn ? _soundOnSprite : _soundOffSprite;
        AudioManager.Instance.SetSoundEffectsMute(!_isSoundOn);
    
    }

    private void OnSettingsButtonClicked()
    {
        GameManager.Instance.changeGameState(GameState.pause);
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        _blackBackGroundObject.SetActive(true);

        _settingsPopUpObject.SetActive(true);

        _blackBackgroundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
        _settingsPopUpObject.transform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
    }

    private void OnResumeButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);


        _blackBackgroundImage.DOFade(0f, _animationDuration).SetEase(Ease.Linear);
        _settingsPopUpObject.transform.DOScale(0, _animationDuration).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            GameManager.Instance.changeGameState(GameState.resume);

            _blackBackGroundObject.SetActive(false);
            _settingsPopUpObject.SetActive(false);
        });
    }

    

}
