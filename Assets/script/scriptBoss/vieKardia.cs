//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet de faire réduire la barre de vie à Kardia lorsque les puzzles sont réussi
// Date: 
//------------------------------------------*

using UnityEngine;
using UnityEngine.UI;

public class vieKardia : MonoBehaviour
{
    [SerializeField] public Image barreKardia;
    //[SerializeField] public Canvas puzzleCode;
    //[SerializeField] public Canvas puzzleLeviers;
    //[SerializeField] public Canvas puzzleQuestion;
    //[SerializeField] public Canvas puzzleJigsaw;

    public static Image imgHealthbar;
    public static int nbVies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per framd
    void Update()
    {
        //if (puzzleCode.tag == "Reussi")
        //{
        //    barreKardia.fillAmount -= 0.5f;
        //    Debug.Log("puzzle code reussi");
        //}

        //if (puzzleLeviers.tag == "Reussi")
        //{
        //    barreKardia.fillAmount -= 0.5f;
        //    Debug.Log("puzzle leviers reussi");
        //}

        //if (puzzleQuestion.tag == "Reussi")
        //{
        //    barreKardia.fillAmount -= 0.5f;
        //    Debug.Log("puzzle question reussi");
        //}

        //if (puzzleJigsaw.tag == "Reussi")
        //{
        //    barreKardia.fillAmount -= 0.5f;
        //    Debug.Log("puzzle jigsaw reussi");
        //}
    }

    private void Awake()
    {
        imgHealthbar = GetComponent<Image>();
        imgHealthbar.fillAmount = 1;
    }
}