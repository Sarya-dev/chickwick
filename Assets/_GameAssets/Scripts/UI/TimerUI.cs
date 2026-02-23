using UnityEngine;
using TMPro;
using DG.Tweening;

public class TimerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform _timerTransform;
    [SerializeField] private TMP_Text _timerText;
    [Header("Settings")]
    [SerializeField] private float _rotationDuration;
    [SerializeField] private Ease _rotationEase;

    private float _elapsedTime;
    private bool _isTimerRunning ;
    private Tween _rotationTween;
    private void Start()
    {
        PlayRotationAnimation();
        startTimer();
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;

    }
    private void GameManager_OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.pause:            
                PauseTimer();
                break;
            case GameState.resume:
                ResumeTimer();   
                break;    
        }
    }
    private void PlayRotationAnimation()
    {
        _rotationTween= _timerTransform.DORotate(new Vector3(0f, 0f, -360f), _rotationDuration, RotateMode.FastBeyond360)
            .SetEase(_rotationEase)
            .SetLoops(-1, LoopType.Restart);
    }
    private void startTimer()
    {
        _isTimerRunning = true;
        _elapsedTime = 0f;
         UptaderTimerUi(); 
        InvokeRepeating(nameof(UptaderTimerUi), 0f, 1f);
       
    }

    private void PauseTimer()
    {
        _isTimerRunning = false;
        CancelInvoke(nameof(UptaderTimerUi));
         _rotationTween.Pause();
        
    }
    private void ResumeTimer()
    {
        if (!_isTimerRunning)
        {
            _isTimerRunning = true;
            InvokeRepeating(nameof(UptaderTimerUi), 0f, 1f);
            _rotationTween.Play();
        }
    }
    private void UptaderTimerUi()
    {
        if (!_isTimerRunning) { return; }
        _elapsedTime += 1f;
        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
