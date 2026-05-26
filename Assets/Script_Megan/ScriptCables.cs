using UnityEngine;

public class ScriptCables : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    public GameObject objetAAfficher;

    private bool btn1Pressed = false;
    private bool btn2Pressed = false;

    public void ClickButton1()
    {
        btn1Pressed = true;
        AfficherCable();
    }

    public void ClickButton2()
    {
        btn2Pressed = true;
        AfficherCable();
    }

    void AfficherCable()
    {
        if (btn1Pressed && btn2Pressed)
        {
            objetAAfficher.SetActive(true);
            Debug.Log("AAAAAAAAAAAALLLLLLOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
        }

    }
}
