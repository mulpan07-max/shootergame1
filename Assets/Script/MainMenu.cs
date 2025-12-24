using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickPlay()
    {
        // Просто переходим на сцену загрузки
        SceneManager.LoadScene("LoadingScene");
    }
}