using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_Curve_Script : MonoBehaviour
{
    public GameObject p0, p1, p2, p3;
	public List<GameObject> listPointsCtrl;
    public int numberOfPoints = 20;
	public int nCtrlPoints = 4;
	int ctrlPointNbr = -1;
	public LineRenderer ctrlPointlineRenderer;
	LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = nCtrlPoints;
		
		Vector3 v0 = p0.transform.position;
		Vector3 v1 = p1.transform.position;
		Vector3 v2 = p2.transform.position;
		Vector3 v3 = p3.transform.position;

		lineRenderer.startColor = Color.red;
		lineRenderer.endColor = Color.red;
		lineRenderer.SetPosition(0, v0);
		lineRenderer.SetPosition(1, v1);
		lineRenderer.SetPosition(2, v2);
		lineRenderer.SetPosition(3, v3);

	}

	// Update is called once per frame
	void Update()
	{
		drawBezier();
		//driveCtrlPoints();
	}

	void drawBezier(){
		lineRenderer.positionCount = numberOfPoints;
		List<Vector3> lstPositions = new List<Vector3>();

		for (int nPoint = 0; nPoint <= numberOfPoints; nPoint++){
			float t = nPoint / (numberOfPoints - 1.0f); //pour chaque parametre t
			Vector3 position = Vector3.zero;

			for (int i = 0; i < 4; i++){
				position += listPointsCtrl[i].transform.position*bersteinCurve(i,t); // somme des positions
			}
			lstPositions.Add(position); // Ajout des listes de position
		}
		lineRenderer.SetPositions(lstPositions.ToArray());
	}

	float bersteinCurve(int i, float t){
		float b;

		b = Mathf.Pow(t, i) * Mathf.Pow(1-t, nCtrlPoints -1 -i) * Factorial(nCtrlPoints -1)/(Factorial(i) * Factorial(nCtrlPoints -1 -i));

		return b;
	}

	static long Factorial(long n)
    {
        return n > 1 ? n * Factorial(n - 1) : 1;
    }

	void driveCtrlPoints()
    {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		if (Input.GetKeyDown(KeyCode.Alpha0))
			ctrlPointNbr = 0;

		if (Input.GetKeyDown(KeyCode.Alpha1))
			ctrlPointNbr = 1;

		if (Input.GetKeyDown(KeyCode.Alpha2))
			ctrlPointNbr = 2;

		if (Input.GetKeyDown(KeyCode.Alpha3))
			ctrlPointNbr = 3;
		//    p3.GetComponent<GameObject>().color = Color.red;
		//p3.color = Color.white;

		if (Input.GetKeyDown(KeyCode.Space))
			ctrlPointNbr = -1;
	}

}