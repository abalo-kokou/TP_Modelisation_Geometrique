using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle_plan : MonoBehaviour
{
    //public int nbRow, nbColumn;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        // Création des structures de données qui accueilleront sommets et  triangles  // Remplissage de la structure sommet 

       int nbRow = 5;
       int nbColumn = 7;

        Vector3[] vertices = new Vector3[nbRow * nbColumn * 4];
        int[] triangles = new int[nbRow * nbColumn * 6];

        for (int i = 0; i < nbColumn; i++)
        {
            for (int j = 0; j < nbRow; j++)
            {
                vertices[(i + j * nbColumn) * 4] = new Vector3(i, j, 0);
                vertices[(i + j * nbColumn) * 4 + 1] = new Vector3(i + 1, j, 0);
                vertices[(i + j * nbColumn) * 4 + 2] = new Vector3(i, j + 1, 0);
                vertices[(i + j * nbColumn) * 4 + 3] = new Vector3(i + 1, j + 1, 0);


                triangles[(i + j * nbColumn) * 6] = (i + j * nbColumn) * 4;
                triangles[(i + j * nbColumn) * 6 + 1] = (i + j * nbColumn) * 4 + 1;
                triangles[(i + j * nbColumn) * 6 + 2] = (i + j * nbColumn) * 4 + 2;
                triangles[(i + j * nbColumn) * 6 + 3] = (i + j * nbColumn) * 4 + 2;
                triangles[(i + j * nbColumn) * 6 + 4] = (i + j * nbColumn) * 4 + 1;
                triangles[(i + j * nbColumn) * 6 + 5] = (i + j * nbColumn) * 4 + 3;


            }
        }


        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}
