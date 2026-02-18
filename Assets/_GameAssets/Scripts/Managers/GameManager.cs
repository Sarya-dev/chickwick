using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("References")]
    [SerializeField] private EggCounterUI _eggCounterUI;

    [Header("Settings")]
    [SerializeField] private int _maxEgg = 5;
    private int _currentEgg;

    private void Awake() {
        Instance = this;
    }
    public void onEggCollected()
    {
        _currentEgg++;
        _eggCounterUI.SetEggCounterText(_currentEgg, _maxEgg);
        if (_currentEgg >= _maxEgg)
        {
            Debug.Log("All Eggs Collected! You Win!");
            _eggCounterUI.SetEggCompleted();

        }
        Debug.Log("Current Eggs: " + _currentEgg);
    }
}
