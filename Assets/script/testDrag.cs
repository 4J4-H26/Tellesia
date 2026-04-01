using UnityEngine;
using UnityEngine.EventSystems;

public class testdrag_avec_UI : MonoBehaviour
{

    [SerializeField] private Canvas canvasPuzzleTest;
    public void TestDragUiPuzzle(BaseEventData data)
    {

        PointerEventData pointeurData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvasPuzzleTest.transform, pointeurData.position, canvasPuzzleTest.worldCamera, out position);

        transform.position = canvasPuzzleTest.transform.TransformPoint(position);


    }
}
