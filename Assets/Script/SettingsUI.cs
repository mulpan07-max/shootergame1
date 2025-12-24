using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("UI")]
    public Slider volumeSlider;
    public Slider sensitivitySlider;

    private void Start()
    {
        
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.7f);
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1f);

        ApplySettings();

        gameObject.SetActive(false); // СКРЫТЬ при старте
    }

    public void OpenSettings()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f; // Пауза
    }

    public void ApplySettings()
    {
        float volume = volumeSlider.value;
        float sensitivity = sensitivitySlider.value;

        AudioListener.volume = volume;

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerPrefs.Save();

        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        ApplySettings();      // сохраняем перед выходом
        gameObject.SetActive(false);
        Time.timeScale = 1f;  // Снять паузу
    }
}

