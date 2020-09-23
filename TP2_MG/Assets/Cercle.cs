using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Cercle : MonoBehaviour
{
    const float PI = 3.1415926f;
    [Range(1,100)]
    public int rayon, nbMeridien;
    public int[] triangles; //structure de données qui accueille les triangles (avec 3 sommets par triangle)
    public Vector3[] vertices; //structure de données qui accueille sommets
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        // Initialisation des structures de données qui accueilleront sommets et  triangles  // Remplissage de la structure sommet 
        vertices = new Vector3[nbMeridien + 1];
        triangles = new int[nbMeridien * 3]; //(avec 3 sommets par triangle)


        vertices[nbMeridien] = new Vector3(0, 0, 0);
        // coordonnées des points ( sur le cercle)
        for (int i = 0; i < nbMeridien; i++)
        {
            vertices[i] = new Vector3(rayon * Mathf.Sin((2 * PI * i + 1) / nbMeridien), 0, rayon * Mathf.Cos((2 * PI * i + 1) / nbMeridien));
        }

        int c = 0;
         for (int i = 0; i < nbMeridien; i++)
         {
             triangles[c] = nbMeridien;
             triangles[c + 1] = (i);
             triangles[c + 2] = ((i) + 1) % nbMeridien;
             c += 3;
         }


        Mesh msh = new Mesh();                                     // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}