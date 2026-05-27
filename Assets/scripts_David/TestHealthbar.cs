using UnityEngine;
using UnityEngine.UI;

public class TestHealthbar : MonoBehaviour
{
    public static Image imgHealthbar;
    public static int nbVies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        imgHealthbar = GetComponent<Image>();
        imgHealthbar.fillAmount = 1;
    }
}
