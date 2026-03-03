using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action<GameState> OnGameStateChanged;
    [Header("References")]
    [SerializeField] private EggCounterUI _eggCounterUI;
    [SerializeField] private WinLoseUI _winLoseUI;

    [Header("Settings")]
    [SerializeField] private int _maxEgg = 5;
    private int _currentEgg;
    private GameState _currentGameState;

    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        changeGameState(GameState.play);
    }
    public void changeGameState(GameState gameState)
    {
        OnGameStateChanged?.Invoke(gameState);
        _currentGameState = gameState;
        Debug.Log("Game State Changed: " + gameState);
    }
    public void onEggCollected()
    {
        _currentEgg++;
        _eggCounterUI.SetEggCounterText(_currentEgg, _maxEgg);
        if (_currentEgg >= _maxEgg)
        {
            
            _eggCounterUI.SetEggCompleted();
            changeGameState(GameState.gameover);
            _winLoseUI.OnGameWin();

        }
    }
    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }
}
