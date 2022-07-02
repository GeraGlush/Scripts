using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject restartMenu;

    public void SetTime(int timeToSet)
    {
        Time.timeScale = timeToSet;
    }

    public void ShowRestartMenu()
    {
        restartMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quid()
    {
        Application.Quit(0);
    }
}
