using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для работы со сценами
using System.Collections;

public class MenuController : MonoBehaviour
{
    // Метод, который мы вызовем при нажатии на кнопку
    public void StartGame()
    {
        StartCoroutine(LoadingTimer());
    }

    IEnumerator LoadingTimer()
    {
        // Здесь можно включить объект с надписью "Загрузка..." на экране
        Debug.Log("Загрузка началась...");

        // Ждем 3 секунды
        yield return new WaitForSeconds(3f);

        // Переходим на сцену PlayScene
        SceneManager.LoadScene("PlayScene");
    }
}