using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;

    public Transform global;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());

    }
    
    IEnumerator LoadAsyncOperation() {
        AsyncOperation gameProgress = SceneManager.LoadSceneAsync("HomePage");
        global.GetComponent<CloudSaveTest>().Load();
        gameProgress.allowSceneActivation = false;
        while (!gameProgress.isDone) {
            _progressBar.fillAmount = gameProgress.progress;

            if (gameProgress.progress >= 0.9f)
            {
                gameProgress.allowSceneActivation = true;
                
            }
            yield return null;
        }
        
    }

}
