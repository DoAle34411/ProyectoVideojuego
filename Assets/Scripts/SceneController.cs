using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        HandleMusicForScene(sceneName);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HandleMusicForScene(scene.name);
    }

    void HandleMusicForScene(string sceneName)
    {
        switch (sceneName)
        {
            case "MainMenu":
            case "LevelSelector":
            case "LevelEnd":
                AudioManager.Instance.PlayMenuMusic();
                break;
            case "Level1":
            case "Level2":
            case "Level3":
            case "Level4":
            case "Level5":
            case "Level6":
            case "Level7":
                AudioManager.Instance.PlayGameMusic();
                break;
            default:
                AudioManager.Instance.StopMusic();
                break;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
