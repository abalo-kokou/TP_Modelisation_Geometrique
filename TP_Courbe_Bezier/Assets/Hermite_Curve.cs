using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Hermite_Curve : MonoBehaviour
{
	public GameObject start, startTangentPoint, end, endTangentPoint;

	private Color scolor = Color.green;
	public Color ecolor = Color.red;
	public float width = 0.2f;
	public int numberOfPoints = 100;
	LineRenderer lineRenderer;

	void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		//les GameObject start, startTangentPoint, end, endTangentPoint
		//sont directement inities dans unity par leur composant correspondant
	}

	void Update()
	{
		// check parameters and components
		if (null == lineRenderer || null == start || null == startTangentPoint
			|| null == end || null == endTangentPoint)
		{
			//Debug.Log("one of start, startTangentPoint, end, endTangentPoint may be null");
			return; // no points specified
		}

		// update line renderer
		lineRenderer.startColor = scolor;
		lineRenderer.endColor = ecolor;
		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;
		if (numberOfPoints > 1) // car il faut au moins 2 points
		{
			lineRenderer.positionCount = numberOfPoints; //positionCount returns the number of vertices in the line.
		}

		// set points of Hermite curve
		Vector3 p0 = start.transform.position;
		Vector3 p1 = end.transform.position;
		Vector3 v0 = startTangentPoint.transform.position - start.transform.position;
		Vector3 v1 = endTangentPoint.transform.position - end.transform.position;
		runHermiteCurve(p0, p1, v0, v1);
	}

	void runHermiteCurve(Vector3 p0, Vector3 p1, Vector3 v0, Vector3 v1) { 
	float u;
	Vector3 pPosition;

		for (int i = 0; i<numberOfPoints; i++)
		{
			u = i / (numberOfPoints - 1.0f); // (numberOfPoints - 1.0f) => intervalle entre les points ou nombre 
												// de segments constituant la courbe 
		 //u=0 => point de depart / u = 1 point d'arrivee
			pPosition = (2.0f * u* u * u - 3.0f * u* u + 1.0f) * p0
		  + (-2.0f * u* u * u + 3.0f * u* u) * p1
		  + (u* u * u - 2.0f * u* u + u) * v0
		  + (u* u * u - u* u) * v1;
			lineRenderer.SetPosition(i, pPosition);
		}
	}
}