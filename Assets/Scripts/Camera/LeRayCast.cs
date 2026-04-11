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
    public LayerMask wallMask;

    [Header("Réglages")]
    [Range(0f, 1f)] public float transparence = 0f;

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
            wallMask
        );

        HashSet<Renderer> mursActuels = new HashSet<Renderer>();

        foreach (RaycastHit hit in hits)
        {

            if (((1 << hit.collider.gameObject.layer) & wallMask) == 0)
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

    void SetAlpha(Renderer r, float alpha)
    {
        foreach (Material mat in r.materials)
        {
            if (mat == null) continue;

            Material instanceMat = mat;

            Color c = instanceMat.color;
            c.a = alpha;
            instanceMat.color = c;

            instanceMat.SetFloat("_Mode", 2);
            instanceMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            instanceMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            instanceMat.SetInt("_ZWrite", 0);

            instanceMat.DisableKeyword("_ALPHATEST_ON");
            instanceMat.EnableKeyword("_ALPHABLEND_ON");
            instanceMat.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            instanceMat.renderQueue = 3000;
        }
    }
}