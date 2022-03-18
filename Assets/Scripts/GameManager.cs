using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameState = false;
    public GameObject levelCompletePanel;
    public void EndGame()
    {
        if(gameState == false)
        {
            gameState = true;
            Debug.Log("Game Over Bhosdike!");
            Invoke("Restart", 2f);
        }
    }

    public void WinEvent()
    {
        //Debug.Log("You win!");
        levelCompletePanel.SetActive(true);
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
