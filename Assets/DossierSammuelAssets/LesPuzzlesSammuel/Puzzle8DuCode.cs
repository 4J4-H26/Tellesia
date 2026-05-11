using UnityEngine;

public class Puzzle8DuCode : MonoBehaviour
{
    [Header("Canvas du puzzle 8")]
    public GameObject CanvasPuzzle8;

    [Header("Image Cube 1")]
    public GameObject Cube1;

    [Header("Image Cube 2")]
    public GameObject Cube2;

    [Header("Image Cube 3")]
    public GameObject Cube3;

    [Header("Image Cube 4")]
    public GameObject Cube4;

    [Header("Cubes gris")]
    public GameObject CubeGris;
    public GameObject CubeGris2;

    [Header("Animation cube")]
    public GameObject AnimationCube;

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
