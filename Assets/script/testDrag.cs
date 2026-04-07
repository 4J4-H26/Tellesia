//------------------------------------------*
// Author : Stella Roy
// Description : Ce script permet de drag le levier vers le bas
// À arranger: La position du levier qui ferme le script?
//------------------------------------------*

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class testdrag_avec_UI : MonoBehaviour
{

    [SerializeField] private Canvas levierRobot;
    [SerializeField] public GameObject interfaceUItest;

    void Start()
    {
    }

    public void TestDragUiPuzzle(BaseEventData data)
    {

        PointerEventData pointeurData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)levierRobot.transform, pointeurData.position, levierRobot.worldCamera, out position);

        transform.position = levierRobot.transform.TransformPoint(position);

        if (levierRobot.transform.position.y < -40)
        {
            interfaceUItest.SetActive(false);
        }
    }
}
