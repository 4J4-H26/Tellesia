// script pour le ray cast
// auteur : sammuel
// date : 10 avril 2026

// desc : ** Pour voir à travers les murs, lorsque nova se déplace..
//           **

using UnityEngine;
using System.Collections.Generic;

public class LeRayCast : MonoBehaviour
{
    [Header("Références")]
    public Transform Nova;
    public LayerMask Murs;

    [Header("Réglages")]
    [Range(0f, 1f)] public float transparence = 0f;

    [Header("Effet Fade")]
    public float vitesse = 5f;

    private HashSet<Renderer> mursCaches = new HashSet<Renderer>();

    void Update()
    {
        if (Nova == null) return;

        Vector3 direction = Nova.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit[] hits = Physics.RaycastAll(
            transform.position,
            direction.normalized,
            distance,
            Murs
        );

        HashSet<Renderer> mursActuels = new HashSet<Renderer>();

        foreach (RaycastHit hit in hits)
        {

            if (((1 << hit.collider.gameObject.layer) & Murs) == 0)
                continue;

            Renderer r = hit.collider.GetComponentInChildren<Renderer>();

            if (r != null)
            {
                SetAlpha(r, transparence);
                mursActuels.Add(r);
            }
        }

        foreach (Renderer r in mursCaches)
        {
            if (!mursActuels.Contains(r) && r != null)
            {
                SetAlpha(r, 1f);
            }
        }

        mursCaches = mursActuels;
    }

    void SetAlpha(Renderer r, float targetAlpha)
    {
        foreach (Material mat in r.materials)
        {
            if (mat == null) continue;

            Color c = mat.color;
            c.a = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime * vitesse);
            mat.color = c;

            if (targetAlpha < 1f)
            {
                mat.SetFloat("_Mode", 2);
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);

                mat.EnableKeyword("_ALPHABLEND_ON");
                mat.renderQueue = 3000;
            }
            else
            {
                mat.SetFloat("_Mode", 0);
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                mat.SetInt("_ZWrite", 1);
                mat.DisableKeyword("_ALPHABLEND_ON");
                mat.renderQueue = -1;
            }
        }
    }
}