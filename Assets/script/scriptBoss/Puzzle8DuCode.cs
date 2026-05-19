//// script pour le puzzle du code du niveau 4
//// auteur : sammuel
//// date : 6 Mai 2026

//// desc : ** ce script gère un puzzle de pige aléatoire.
////           Nova doit faire apparaître Cube3 et Cube4
////           en même temps pour réussir le puzzle. **

//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class Puzzle8DuCode : MonoBehaviour
//{
//    [Header("Canvas du puzzle 8")]
//    public GameObject CanvasPuzzle8;

//    [Header("Image chiffres Cube 3")]
//    public GameObject ChiffreCube3;
//    public GameObject Chiffre2Cube3;

//    [Header("Image chiffres Cube 4")]
//    public GameObject ChiffreCube4;
//    public GameObject Chiffre2Cube4;

//    [Header("Image Cube 3")]
//    public GameObject Cube3;

//    [Header("Image Cube 4")]
//    public GameObject Cube4;

//    [Header("Cubes gris")]
//    public GameObject CubeGris1;
//    public GameObject CubeGris2;

//    [Header("Animation cube")]
//    public GameObject AnimationCube3;
//    public GameObject AnimationCube4;

//    private List<GameObject> baseCube1;
//    private List<GameObject> baseCube2;

//    private List<GameObject> poolCube1;
//    private List<GameObject> poolCube2;

//    void Start()
//    {
//        Cube3.SetActive(false);
//        Cube4.SetActive(false);

//        ChiffreCube3.SetActive(false);
//        Chiffre2Cube3.SetActive(false);

//        ChiffreCube4.SetActive(false);
//        Chiffre2Cube4.SetActive(false);

//        AnimationCube3.SetActive(false);
//        AnimationCube4.SetActive(false);

//        baseCube1 = new List<GameObject>()
//        {
//            ChiffreCube3,
//            Chiffre2Cube3,
//            Cube3
//        };

//        baseCube2 = new List<GameObject>()
//        {
//            ChiffreCube4,
//            Chiffre2Cube4,
//            Cube4
//        };

//        poolCube1 = new List<GameObject>(baseCube1);
//        poolCube2 = new List<GameObject>(baseCube2);
//    }

//    public void CliquerCubeGris1()
//    {
//        StartCoroutine(PigerCube(CubeGris1, AnimationCube3, poolCube1, baseCube1));
//    }

//    public void CliquerCubeGris2()
//    {
//        StartCoroutine(PigerCube(CubeGris2, AnimationCube4, poolCube2, baseCube2));
//    }

//    IEnumerator PigerCube(
//        GameObject cubeGris,
//        GameObject animationCube,
//        List<GameObject> pool,
//        List<GameObject> baseList
//    )
//    {
//        cubeGris.SetActive(false);

//        animationCube.SetActive(true);

//        yield return new WaitForSeconds(1f);

//        animationCube.SetActive(false);

//        foreach (GameObject obj in baseList)
//            obj.SetActive(false);

//        if (pool.Count == 0)
//        {
//            pool.AddRange(baseList);
//        }

//        if (pool.Count == 0)
//        {
//            yield break;
//        }

//        int index = Random.Range(0, pool.Count);

//        GameObject result = pool[index];

//        if (result != null)
//            result.SetActive(true);

//        pool.RemoveAt(index);

//        Debug.Log(result.name);

//        VerifierVictoire();
//    }

//    void VerifierVictoire()
//    {
//        bool cube3Visible = Cube3.activeSelf;
//        bool cube4Visible = Cube4.activeSelf;

//        bool chiffresInvisible =
//            !ChiffreCube3.activeSelf &&
//            !Chiffre2Cube3.activeSelf &&
//            !ChiffreCube4.activeSelf &&
//            !Chiffre2Cube4.activeSelf;

//        if (cube3Visible && cube4Visible && chiffresInvisible)
//        {
//            Debug.Log("reussi");
//            Invoke("FermerCanvas", 3f);
//        }
//    }
//    x
//    void FermerCanvas()
//    {
//        CanvasPuzzle8.SetActive(false);
//    }
//}