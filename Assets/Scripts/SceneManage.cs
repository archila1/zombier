using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManage : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainMenu;
    CanvasGroup mainMenuA;
    CanvasGroup settingsMenuA;

    float duration = 1f;

    private void Start()
    {
        mainMenuA = mainMenu.GetComponent<CanvasGroup>();
        settingsMenuA = settingsMenu.GetComponent<CanvasGroup>();
    }

    public void GoToSettings()
    {
        mainMenuA.interactable = false;
        StartCoroutine(FadeCanvasGroup(mainMenuA, mainMenuA.alpha, 0f, mainMenu));
        settingsMenu.SetActive(true);      
        StartCoroutine(FadeCanvasGroup(settingsMenuA, settingsMenuA.alpha, 1f, settingsMenu));
        settingsMenuA.interactable=true;
    }

    public void GoToMenu()
    {
        settingsMenuA.interactable = false;
        StartCoroutine(FadeCanvasGroup(settingsMenuA, settingsMenuA.alpha, 0f,  settingsMenu));
        mainMenu.SetActive(true);
        StartCoroutine(FadeCanvasGroup(mainMenuA, mainMenuA.alpha, 1f, mainMenu));
        mainMenuA.interactable = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
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
        if(canvGroup.alpha <= 0) item.SetActive(false);

    }


    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
 
    


}
