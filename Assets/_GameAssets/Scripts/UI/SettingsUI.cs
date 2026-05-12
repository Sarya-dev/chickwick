using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MaskTransitions;

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
    [Header("Settings")]
    [SerializeField] private float _animationDuration;
    private Image _blackBackgroundImage;

    private void Awake()
    {
        _blackBackgroundImage = _blackBackGroundObject.GetComponent<Image>();
        _settingsPopUpObject.transform.localScale = Vector3.zero;
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _mainMenuButton.onClick.AddListener(() =>
        {
            TransitionManager.Instance.LoadLevel(Consts.SceneNames.MENU_SCENE);
           
        });

    }


    private void OnSettingsButtonClicked()
    {
        GameManager.Instance.changeGameState(GameState.pause);
        _blackBackGroundObject.SetActive(true);

        _settingsPopUpObject.SetActive(true);

        _blackBackgroundImage.DOFade(0.8f, _animationDuration).SetEase(Ease.Linear);
        _settingsPopUpObject.transform.DOScale(1.5f, _animationDuration).SetEase(Ease.OutBack);
    }

    private void OnResumeButtonClicked()
    {

        _blackBackgroundImage.DOFade(0f, _animationDuration).SetEase(Ease.Linear);
        _settingsPopUpObject.transform.DOScale(0, _animationDuration).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            GameManager.Instance.changeGameState(GameState.resume);

            _blackBackGroundObject.SetActive(false);
            _settingsPopUpObject.SetActive(false);
        });
    }

    

}
