using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingProcess : MonoBehaviour
{
    void Start()
    {
        // Как только сцена загрузки открылась, запускаем таймер
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        // Ждем ровно 3 секунды
        yield return new WaitForSeconds(3f);

        // Переходим к самой игре
        SceneManager.LoadScene("PlayScene");
    }
}