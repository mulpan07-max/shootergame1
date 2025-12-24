using UnityEngine;
using UnityEngine.UI;

public class SettingsUI1 : MonoBehaviour
{
    [Header("UI")]
    public Slider volumeSlider;
    public Slider sensitivitySlider;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.7f);
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1f);

        gameObject.SetActive(false); // просто скрываем
    }

    public void OpenSettings()
    {
        gameObject.SetActive(true);
    }

    public void ApplySettings()
    {
        float volume = volumeSlider.value;
        float sensitivity = sensitivitySlider.value;

        AudioListener.volume = volume;

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerPrefs.Save();
    }

    public void CloseSettings()
    {
        ApplySettings();
        gameObject.SetActive(false);
    }
}
