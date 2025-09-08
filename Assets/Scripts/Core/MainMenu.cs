using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private string _gameSceneName = "GameScene";

    public void StartGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }

}