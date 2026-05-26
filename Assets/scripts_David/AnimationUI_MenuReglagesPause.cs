using UnityEngine;

public class AnimationUI_MenuReglagesPause : MonoBehaviour
{
    public GameObject Menu;
    public Transform MenuPosition;
    public Transform MenuReferenceOuvert;
    public Transform MenuReferenceFerme;
    [SerializeField] LeanTweenType easetype;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bougerMenuPause();
        }
    }

    public void bougerMenuPause()
    {
        if (MenuPosition.position.x == MenuReferenceFerme.position.x)
        {
            LeanTween.moveX(Menu, MenuReferenceOuvert.position.x, 0.2f).setEase(easetype);
            LeanTween.moveY(Menu, MenuReferenceOuvert.position.y, 0.2f).setEase(easetype);

        }
        

        if (MenuPosition.position.x == MenuReferenceOuvert.position.x)
        {
            LeanTween.moveX(Menu, MenuReferenceFerme.position.x, 0.2f).setEase(easetype);
            LeanTween.moveY(Menu, MenuReferenceFerme.position.y, 0.2f).setEase(easetype);
            
        }
    }
}
