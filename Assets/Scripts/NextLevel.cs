using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void LoadNeextLevel()
    {
        //Debug.Log("Welcome to Level 2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
