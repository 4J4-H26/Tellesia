// script pour controler le menu accueil
// auteur : sammuel
// date : 14-15 avril 2026

// desc : ** menu
//           **

using UnityEngine;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    public GameObject video;
    public GameObject canvas;
    public GameObject canvas2;

    private VideoPlayer videoPlayer;

    public GameObject environnement;

    void Start()
    {
        videoPlayer = video.GetComponent<VideoPlayer>();

        videoPlayer.Prepare(); 

        video.SetActive(false);
        canvas.SetActive(true);
        canvas2.SetActive(false);
    }
    public void Commencer()
    {
        canvas.SetActive(false);
        environnement.SetActive(false);
        video.SetActive(true);
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += PlayVideo;
    }
    void PlayVideo(VideoPlayer vp)
    {
        vp.prepareCompleted -= PlayVideo;
        vp.Play();

        vp.loopPointReached += FinVideo;
    }

    void FinVideo(VideoPlayer vp)
    { 
        
        video.SetActive(false);
       
        Invoke("Delai", 0.5f);
    }

    void Delai()
    {
        environnement.SetActive(true);
        canvas2.SetActive(true);
        
    }
}