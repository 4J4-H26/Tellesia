using UnityEngine;

public class prendreDegat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerteVie()
    {

        vieNova.imgHealthbar.fillAmount -= 0.25f;
    }

    public void degatsboom()
    {

        vieKardia.imgHealthbar.fillAmount -= 0.25f;
    }
}
