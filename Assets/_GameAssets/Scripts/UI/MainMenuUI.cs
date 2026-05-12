using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
 
   [SerializeField] private Button _mainMenuButton;
   
  
    void Awake()
    {
       
        _mainMenuButton.onClick.AddListener(() =>
        {
           SceneManager.LoadScene(Consts.SceneNames.MENU_SCENE); 
        });
    }

}
