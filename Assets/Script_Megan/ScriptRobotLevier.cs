//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de déplacer le
// levier quand on clique
//------------------------------------------*
using UnityEngine;
using UnityEngine.UI;

public class ScriptRobotLevier : MonoBehaviour
{
    public Canvas canvaLevierTuto;
    public Button levier;
    public Animator animTranslation;
    public GameObject robot;
    public GameObject positionRobotApresLevier;//mettre un gameobject empty avec la position du robot qui a bougé

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levier = levier.GetComponent<Button>();
        animTranslation.enabled = false;
    }

    public void clickRotation()
    {
        animTranslation.enabled = true;
        // Le robot translate ici
    }
}
