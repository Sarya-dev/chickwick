using UnityEngine;
using TMPro;
using DG.Tweening;
public class EggCounterUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text _eggCounterText;
    [Header("Settings")]
    private RectTransform _eggCounterRectTransform;
    [SerializeField] private Color _eggCounterColor;
    [SerializeField] private float _eggCounterColorDuration;
    [SerializeField] private float _eggScaleDuration;


    private void Awake()
    {
        _eggCounterRectTransform = _eggCounterText.gameObject.GetComponent<RectTransform>();
    }

    public void SetEggCounterText(int counter, int max)
    {
        _eggCounterText.text = counter.ToString() + "/" + max.ToString();
    }

    public void SetEggCompleted()
    {
        _eggCounterText.DOColor(_eggCounterColor, _eggCounterColorDuration);
        _eggCounterRectTransform.DOScale(1.2f, _eggScaleDuration).SetEase(Ease.OutBack);
    }

}
