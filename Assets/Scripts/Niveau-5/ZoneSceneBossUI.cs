//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet 
//------------------------------------------*
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneSceneBossUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nova"))
        {
            Debug.Log("Charger scène");
            SceneManager.LoadScene("Niveau5_UI_boss");
        }
    }
}
