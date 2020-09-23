using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylindre : MonoBehaviour
{
    const float PI = 3.1415926f;
    [Range(1, 100)]
    public int rayon, hCylindre, nbMeridien;
    public int[] triangles; //structure de données qui accueille les triangles (avec 3 sommets par triangle)
    public Vector3[] vertices; //structure de données qui accueille sommets
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        // Création des structures de données qui accueilleront sommets et  triangles  // Remplissage de la structure sommet 

        vertices = new Vector3[nbMeridien * 2 + 2]; // car on deux cercles/disques => (nbMeridien + 1) + (nbMeridien + 1)
        triangles = new int[nbMeridien * 4 * 3]; // car on 4 triangles en tout par méridien et par triangle on 3 sommets


        vertices[nbMeridien * 2] = new Vector3(0, 0, 0);
        vertices[nbMeridien * 2 + 1] = new Vector3(0, hCylindre, 0); // par rapport aux facettes du cylindre

        for (int i = 0; i < nbMeridien; i++)
        {
            vertices[i] = new Vector3(rayon * Mathf.Sin((2 * PI * i + 1) / nbMeridien), 0, rayon * Mathf.Cos((2 * PI * i + 1) / nbMeridien)); // (x, 0, z) avec y=0
            vertices[i + nbMeridien + 1] = new Vector3(rayon * Mathf.Sin((2 * PI * i + 1) / nbMeridien), hCylindre, rayon * Mathf.Cos((2 * PI * i + 1) / nbMeridien)); // (x, h, z) avec y=h
        }

        int c = 0;

        for (int i = 0; i < nbMeridien; i++)
        {
            triangles[c] = 
            triangles[c + 1] = 
            triangles[c + 2] = 

            triangles[c + 3] = 
            triangles[c + 4] = 
            triangles[c + 5] = 

            triangles[c + 6] = 
            triangles[c + 7] =
            triangles[c + 8] = 

            triangles[c + 9] = 
            triangles[c + 10] = 
            triangles[c + 11] = 

            c += 12;
        }





        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }
}