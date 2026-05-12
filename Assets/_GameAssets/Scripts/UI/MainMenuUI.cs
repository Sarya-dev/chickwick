using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MaskTransitions;

public class MainMenuUI : MonoBehaviour
{
 
   [SerializeField] private Button _mainMenuButton;
   
  
    void Awake()
    {
       
        _mainMenuButton.onClick.AddListener(() =>
        {
            TransitionManager.Instance.LoadLevel(Consts.SceneNames.MENU_SCENE);
           
        });
    }

}
