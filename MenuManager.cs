using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Замените на имя вашей сцены
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // Работает только в билде
    }
}
