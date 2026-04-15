using UnityEngine;

public class AnimationUI_Accueil : MonoBehaviour
{
    public GameObject Menu;
    public Transform MenuReference;
    [SerializeField] LeanTweenType easetype;

    void Start()
    {

    }

    void Update()
    {

    }

    public void BougerMenu()
    {
        LeanTween.moveX(Menu, MenuReference.position.x, 2f).setEase(easetype);
    }
}