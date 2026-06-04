using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
   [SerializeField] private GameManager _gameManager;

   private PlayableDirector _playableDirector;

    void Awake()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }
    void OnEnable()
    {
        _playableDirector.Play();
        _playableDirector.stopped += OnTimeLineFinished;
    }

    private void OnTimeLineFinished(PlayableDirector director)
    {
        _gameManager.changeGameState(GameState.play);
    }
}
