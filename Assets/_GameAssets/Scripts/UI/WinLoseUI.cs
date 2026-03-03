using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class WinLoseUI : MonoBehaviour
{
   [Header("References")]
   [SerializeField] private GameObject _blackBackground;
   [SerializeField] private GameObject _winPopup;
   [SerializeField] private GameObject _losePopup;
   [Header("Settings")]
   [SerializeField] private float transitionDuration = 0.3f;

   private Image blackBackgroundImage;
   private RectTransform winTransform;
   private RectTransform loseTransform;

    void Awake()
    {
        blackBackgroundImage = _blackBackground.GetComponent<Image>();
        winTransform = _winPopup.GetComponent<RectTransform>();
        loseTransform = _losePopup.GetComponent<RectTransform>();



    }

    public void OnGameWin()
    {
        _blackBackground.SetActive(true);
        _winPopup.SetActive(true);
        blackBackgroundImage.DOFade(0.8f, transitionDuration).SetEase(Ease.Linear);
        winTransform.DOScale(1.5f, transitionDuration).SetEase(Ease.OutBack);
    }

    public void OnGameLose()
    {
        _blackBackground.SetActive(true);
        _losePopup.SetActive(true);
        blackBackgroundImage.DOFade(0.8f, transitionDuration).SetEase(Ease.Linear);
        loseTransform.DOScale(1.5f, transitionDuration).SetEase(Ease.OutBack);
    }



    
    void Update()
    {
        
    }
}
