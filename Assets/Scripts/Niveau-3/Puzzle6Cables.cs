// script pour gérer les cables
// auteur : sammuel
// date : 14 Mars 2026

// desc : Nova devra connecter les cables en évitant les obstacles 
//        sinon faudra recommencer au début


using System.Collections.Generic;
using UnityEngine;

public class Puzzle6Cables : MonoBehaviour
{
    // ** on déclare les variables **

        [Header("linerenderer")]
        public LineRenderer ligneCable;

        [Header("pointage")]
        private List<Vector3> points = new List<Vector3>();

        [Header("état booléen quand Nova trace")]
        private bool tracer = false;

    void Start()
    {
        ligneCable.positionCount = 0;
    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            Commencer();
        }

        if (Input.GetMouseButton(0) && tracer)
        {
           TracerCable();
        }

        if (Input.GetMouseButtonUp(0))
        {
            tracer = false;
        }
    }

    void Commencer()
    {
        tracer = true;
        points.Clear();
        ligneCable.positionCount = 0;
    }

    void TracerCable()
    {
        Vector3 mouvtDeLaSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouvtDeLaSouris.z = 0;

        if (points.Count == 0)
        {
            points.Add(mouvtDeLaSouris);
            ligneCable.positionCount = 1;
            ligneCable.SetPosition(0, mouvtDeLaSouris);
            return;
        }

        Vector3 dernierPoint = points[points.Count - 1];
        Vector3 direction = mouvtDeLaSouris - dernierPoint;

     
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {

            mouvtDeLaSouris.y = dernierPoint.y;
        }
        else
        {

            mouvtDeLaSouris.x = dernierPoint.x;
        }


        if (Vector3.Distance(dernierPoint, mouvtDeLaSouris) > 0.2f)
        {
            points.Add(mouvtDeLaSouris);
            ligneCable.positionCount = points.Count;
            ligneCable.SetPositions(points.ToArray());
        }
    }

 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Mur"))
        {
            Recommencer();
        }

        if (collision.CompareTag("Arrivee"))
        {
            Reussit();
        }
    }

    void Recommencer()
    {
        points.Clear();
        ligneCable.positionCount = 0;
        tracer = false;
    }

    void Reussit()
    {
        tracer = false;
    }
}