using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipperCinematique : MonoBehaviour
{
    public GameObject cinematique;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cinematique.SetActive(false);
        }
    }
}