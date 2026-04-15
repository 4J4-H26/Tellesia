using UnityEngine;
using UnityEngine.Video;

public class Menu : MonoBehaviour
{
    public GameObject video;
    public GameObject canvas;
    public GameObject canvas2;

    private VideoPlayer videoPlayer;

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
        canvas2.SetActive(true);
    }
}