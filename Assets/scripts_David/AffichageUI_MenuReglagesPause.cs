using UnityEngine;

public class AffichageUI_MenuReglagesPause : MonoBehaviour
{
    public GameObject MenuReglage;

    void Start()
    {
        MenuReglage.SetActive(false);
    }
    public void ControleMenuReglage()
    {
        if (MenuReglage.activeSelf == false)
        {
            MenuReglage.SetActive(true);
        }
        else if (MenuReglage.activeSelf == true)
        {
            MenuReglage.SetActive(false);
        }
        
    }
}
