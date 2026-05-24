using UnityEngine;
using UnityEngine.SceneManagement;

public class RecommenceNiv5 : MonoBehaviour
{
    public string recommencerNiv;

    public void LoadScene() 
    {
        SceneManager.LoadScene(3);
    }
}
