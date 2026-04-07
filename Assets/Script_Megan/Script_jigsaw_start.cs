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

public class Script_jigsaw_start : MonoBehaviour
{
    //------------------------------------------*
    // VARIABLES
    //------------------------------------------*
    [Range(2, 6)]
    [SerializeField] private int difficulty = 4;

    [SerializeField] private List<Texture2D> imageTextures;
    [SerializeField] private Transform levelSelectPanel;
    [SerializeField] private Image levelSelectPrefab;

    private List<Transform> pieces;
    private Vector2Int dimensions;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // UI caché
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
    /*public void startGame(Texture2D jigsawTexture){
        // Garde les pièces dans un tableau
        pieces = new List<Transform>();

        // Calculer la taille des pièces (avec la difficulté)
        dimensions = GetDimensions(jigsawTexture, difficulty);


            return dimensions;
        }
    }

    /**Vector2Int GetDimensions(Texture2D jigsawTexture, int difficulty){
         Vector2Int dimensions = Vector2Int.zero;

         //Faire des pièce carrées
         if(jigsawTexture.width < jigsawTexture.height) {
             dimensions.x = difficulty;
             dimensions.y = (difficulty * jigsawTexture.height) / jigsawTexture.width;
         }else{
             dimensions.x = difficulty * jigsawTexture.width / jigsawTexture.height;
             dimensions.y = difficulty;
         }
    }*/
}
