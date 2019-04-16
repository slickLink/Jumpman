using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundstuff : MonoBehaviour
{
    private float[] x = { -10, 300 };
    private float[] y = { -10, 15 };
    private float[] z = { 7, 50 };

    public GameObject cube;
	// Use this for initialization
	void Start () {
        float xCor;
        float yCor;
        float zCor;
        Vector3 v;

        for(int i = 0; i < 1000; i++)
        {
            xCor = Random.Range(x[0], x[1]);
            yCor = Random.Range(y[0], y[1]);
            zCor = Random.Range(z[0], z[1]);

            v = new Vector3(xCor, yCor, zCor);
            
            Instantiate(cube, v, Quaternion.identity);
        }
	}
	
}
