using UnityEngine;
using UnityEngine.SceneManagement;

public class choixFin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finDetruire()
    {
        Invoke("delaiPasDrtuire", 1f);
    }

    public void finPasDetruire()
    {
        Invoke("DelaiDetruire", 1f);
    }

    void DelaiDetruire()
    {
        SceneManager.LoadScene(1);
    }

    void delaiPasDrtuire()
    {
        SceneManager.LoadScene(0);
    }
}
