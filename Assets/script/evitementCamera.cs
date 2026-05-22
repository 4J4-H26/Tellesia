//using UnityEditor.AdaptivePerformance.Editor;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class evitementCamera : MonoBehaviour
//{
//    public AudioClip sonAttraperCam;
//    AudioSource AudioSource;

//    private void Start()
//    {
//        AudioSource = GetComponent<AudioSource>();
//    }
//    public void OnTriggerEnter(Collider Nova)
//    {
//        if (Nova.gameObject.tag == "Player") 
//        {
//            Debug.Log("AHSJDHA)");
//            AudioSource.PlayOneShot(sonAttraperCam, 1f);
//            Invoke("ReloadScene", 1f);
//        }
//    }

//    public void ReloadScene()
//    {
//        SceneManager.LoadScene(0);
//    }
//}
