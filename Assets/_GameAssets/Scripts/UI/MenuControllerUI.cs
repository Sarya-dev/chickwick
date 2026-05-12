using MaskTransitions;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerUI : MonoBehaviour
{
   [SerializeField] private Button _playButton;
   
   [SerializeField] private Button _quitButton;
   
   [SerializeField] private Button _howToPlayButton;
   
   
   [SerializeField] private Button _creditsButton;
    void Awake()
    {
        _playButton.onClick.AddListener(() =>
        {
           TransitionManager.Instance.LoadLevel(Consts.SceneNames.GAME_SCENE);
        });

        _howToPlayButton.onClick.AddListener(() =>
        {
            TransitionManager.Instance.LoadLevel(Consts.SceneNames.HOWTOPLAY_SCENE);
            
        });

        _creditsButton.onClick.AddListener(() =>
        {
            TransitionManager.Instance.LoadLevel(Consts.SceneNames.CREDITS_SCENE);
          
        });

        _quitButton.onClick.AddListener(() =>
        {
            Debug.Log("quitting the game");
            Application.Quit();
        });
    }

}
