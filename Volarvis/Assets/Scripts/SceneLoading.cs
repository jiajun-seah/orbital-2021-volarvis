using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }
    
    IEnumerator LoadAsyncOperation() {
        AsyncOperation gameProgress = SceneManager.LoadSceneAsync("LoadedFinish");
        while (gameProgress.progress < 1) {
            _progressBar.fillAmount = gameProgress.progress;
            yield return new WaitForEndOfFrame();
        }
    }

}
