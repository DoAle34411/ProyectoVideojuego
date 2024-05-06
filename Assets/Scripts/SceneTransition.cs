using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName; // Name of the scene to transition to

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if it's the player that collided
        {
            SceneManager.LoadScene(sceneName); // Load the specified scene  

        }
    }
}

