using UnityEngine;

public class StateController : MonoBehaviour
{
    private PlayerState _currentplayerstate = PlayerState.Idle;

    private void Start()
    {
        ChangeState(PlayerState.Idle);
    }
    public void ChangeState(PlayerState newplayerstate)
    {
        if (_currentplayerstate == newplayerstate) { return; }
        _currentplayerstate = newplayerstate;
    }
    public PlayerState returnstate()
    {
        return _currentplayerstate;
    }
}
