using UnityEngine;
using System.Collections; 
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action<GameState> OnGameStateChanged;
    [Header("References")]
    [SerializeField] private CatController _catController;
    [SerializeField] private EggCounterUI _eggCounterUI;
    [SerializeField] private WinLoseUI _winLoseUI;
    [SerializeField] private PlayerHealthUI _playerHeathUI;

    [Header("Settings")]
    [SerializeField] private int _maxEgg = 5;
    [SerializeField] private float _delay;
    private int _currentEgg;
    private GameState _currentGameState;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        HealthManager.Instance.OnPlayerDeath += HealthManager_OnPlayerDeath;
        _catController.OnCatCatched += CatController_OnCatCatched;
    }

    private void CatController_OnCatCatched()
    {
        _playerHeathUI.AnimateDamageForAll();
        StartCoroutine(OnGameOver());
    }

    private void HealthManager_OnPlayerDeath()
    {
        StartCoroutine(OnGameOver()); 
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
    private IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(_delay);
        changeGameState(GameState.gameover);
        _winLoseUI.OnGameLose();
        
    }
   
    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }
}
