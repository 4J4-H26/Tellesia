using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject LoadingScreen;
    public Image vaisseau;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LooadSceneAsync(sceneId));
    }

    IEnumerator LooadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progresValeur = Mathf.Clamp01(operation.progress / 0.9f);


            yield return null;
        }
    }
}
