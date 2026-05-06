using UnityEngine;

public class Puzzle8DuCode : MonoBehaviour
{
    [Header("Canvas du puzzle 8")]
    public GameObject CanvasPuzzle8;


    [Header("Images Cube 1")]
    public GameObject imagedefaut;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;

    [Header("Images Cube 2")]
    public GameObject imagedefaut2;

    public GameObject image7;
    public GameObject image8;
    public GameObject image9;
    public GameObject image10;
    public GameObject image11;
    public GameObject image12;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanvasPuzzle8.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
