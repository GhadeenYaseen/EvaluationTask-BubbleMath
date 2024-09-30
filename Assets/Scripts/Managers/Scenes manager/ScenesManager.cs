using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenesManager : MonoBehaviour
{
    [HideInInspector] public static ScenesManager ScenesManagerInstance {get; private set;}
    
    [SerializeField] public GameObject LoadingScreen;


    private void Awake()
    {
        if (ScenesManagerInstance != null && ScenesManagerInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            ScenesManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartLoading(string sceneName) 
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string scenmeName) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenmeName);
        
        LoadingScreen.SetActive(true);

        while (! operation.isDone) 
        {
            yield return null;
        }

        LoadingScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
