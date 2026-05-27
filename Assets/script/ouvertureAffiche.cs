using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class ouvertureAffiche : MonoBehaviour
{
    public GameObject UIaffiche;
    private bool UIouvert;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIouvert = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && UIouvert)
        {
            UIouvert = false;
            UIaffiche.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E) && !UIouvert)
        {
            UIouvert = true;
            UIaffiche.SetActive(true);
        }
    }

    public void exitAffiche()
    {
        if (UIouvert)
        {
            UIouvert = false;
            UIaffiche.SetActive(false);
        }
        else
        {
            UIouvert = true;
            UIaffiche.SetActive(true);
        }
    }

    public void ouvrirAffiche()
    {
        
    }
}
