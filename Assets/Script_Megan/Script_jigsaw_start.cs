//------------------------------------------*
// Author : Megan Desjardins
// Description : Ce script permet de faire apparaître et disparaître
// le puzzle de jigsaw et de découper un image pour ensuite déplacer
// les pièces et avoir un son de réussite + l'image dans son inventaire
// https://www.youtube.com/watch?v=OFC_UUaS4gs
//------------------------------------------*
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Script_jigsaw_start : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    private int emptyLocation;
    private int size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // UI caché
        size = 3;
        CreateGamePieces(0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        // UI apparaît et activation du script du jigsaw
    }

    //------------------------------------------*
    // FONCTIONS
    //------------------------------------------*

    //------------------------------------------*
    // Fonction startGame
    // Description : 
    //------------------------------------------*
    private void CreateGamePieces(float gapThickness)
    {
        //La largeur de chaque pièce
        float width = 1 / (float)size;
        for(int row = 0; row < size; row++)
        {
            for(int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                // Les pièces vont de -1 à +1
                piece.localPosition = new Vector3(-1 + (2 * width * col) * width,
                                                  +1 - (2 * width * row) - width,
                                                  0);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                // Espace vide en bas à droite
                if((row == size - 1) && (col == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    // Étendre la texture sur toutes les pièces avec les UV
                    // Ordre des UV : (0,1) (1,1) (0,0) (1,0)
                    float gap = gapThickness;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
                    //Assigner les UV au mesh
                    mesh.uv = uv;
                }
            }
        }
    }//fin CreateGamePieces

}
