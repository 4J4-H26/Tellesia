using UnityEngine;

public class TestPerteVieHealthbar : MonoBehaviour
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
        TestHealthbar.imgHealthbar.fillAmount -= 0.25f;
        
    }
}
