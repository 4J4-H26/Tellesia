using UnityEngine;

public class AnimationUI_Accueil : MonoBehaviour
{
    public GameObject Menu;
    public Transform MenuReference;
    [SerializeField] LeanTweenType easetype;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BougerMenu();
    }



    public void BougerMenu()
    {
        LeanTween.moveX(Menu, MenuReference.position.x, 2f).setEase(easetype);
    }

}