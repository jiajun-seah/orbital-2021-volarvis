using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SplashPage");
    }
}
