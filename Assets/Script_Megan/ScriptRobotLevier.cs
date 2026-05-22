//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de déplacer le
// levier quand on clique et de déplacer le robot
//------------------------------------------*
using UnityEngine;
using UnityEngine.UI;

public class ScriptRobotLevier : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    public Button levier;
    public Image levierBase;
    public Animator animTranslation;
    public GameObject robot;
    bool playerClose = false;
    // Mettre un gameobject empty avec la position du
    // robot qui a bougé
    public GameObject positionRobotApresLevier;

    [Header("Canvas")]
    public GameObject CanvasDuLevierRobot;

    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    // Start
    void Start()
    {
        // Désactiver les les éléments au début
        levier = levier.GetComponent<Button>();
        //levier.gameObject.SetActive(false);
        //levierBase.gameObject.SetActive(false);
        animTranslation.enabled = false;
    }

    // Update
    void Update()
    {
        // Si on click sur E et que Nova est dans le collider
        if(playerClose && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("Puzzle s'affiche");
            levier.gameObject.SetActive(true);
            levierBase.gameObject.SetActive(true);
        }
    }

    //------------------------------------------*
    // Fonction PiecePlaced
    // Description : Cette fonction lance l'animation du
    // levier et change la position du robot quand on click
    //------------------------------------------*
    public void clickTranslation()
    {
        animTranslation.enabled = true;
        robot.transform.position = positionRobotApresLevier.transform.position;
    }

    //------------------------------------------*
    // COLLISIONS
    // Description : Si Nova entre dans le Collider
    // autour du PuzzleRobotManager
    //------------------------------------------*

    private void OnTriggerEnter(Collider other) 
    {
        // --- Ajouter le tag "Nova" au perso *
        if(other.CompareTag("Nova"))
        {
            //Debug.Log("Nova est proche");
            playerClose = true;
        }
    }
}
