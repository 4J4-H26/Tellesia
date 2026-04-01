using System;
using UnityEngine;

public class testApparaitreUi : MonoBehaviour
{

    [SerializeField] public GameObject interfaceUItest;

    //you can assign this key in the inspector as your inventory key
    //the default is I key in this case
    public KeyCode UIInputKey = KeyCode.E;

    private bool UIouvert;

    // Start is called on the first frame
    private void Start()
    {
        UIouvert = interfaceUItest.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        //if you press the inventory key, it will enable/disable the inventory menu appropriately
        if (Input.GetKeyDown(UIInputKey))
        {
            if (UIouvert)
            {
                UIouvert = false;
                interfaceUItest.SetActive(false);
            }
            else
            {
                UIouvert = true;
                interfaceUItest.SetActive(true);
            }
        }
    }
}
