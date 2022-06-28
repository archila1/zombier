using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
//using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenu;
    CanvasGroup mainMenuA;
    CanvasGroup settingsMenuA;

    float duration = 1f;


    void Start()
    {
        string[] names = QualitySettings.names;
        mainMenuA = mainMenu.GetComponent<CanvasGroup>();
        settingsMenuA = settingsMenu.GetComponent<CanvasGroup>();
    }

    public void MasterAudioVolume(float volume)
    {
        AudioListener.volume = volume;      
    }

    public void GraphicsQuality(int value)
    {
        QualitySettings.SetQualityLevel(value, true);
    }

    public void GoToSettings()
    {
        mainMenuA.interactable = false;
        StartCoroutine(FadeCanvasGroup(mainMenuA, mainMenuA.alpha, 0f, mainMenu));
        settingsMenu.SetActive(true);
        StartCoroutine(FadeCanvasGroup(settingsMenuA, settingsMenuA.alpha, 1f, settingsMenu));
        settingsMenuA.interactable = true;
    }

    public void GoToMenu()
    {
        settingsMenuA.interactable = false;
        StartCoroutine(FadeCanvasGroup(settingsMenuA, settingsMenuA.alpha, 0f, settingsMenu));
        mainMenu.SetActive(true);
        StartCoroutine(FadeCanvasGroup(mainMenuA, mainMenuA.alpha, 1f, mainMenu));
        mainMenuA.interactable = true;
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup canvGroup, float start, float end, GameObject item)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
        if (canvGroup.alpha <= 0) item.SetActive(false);

    }
}
