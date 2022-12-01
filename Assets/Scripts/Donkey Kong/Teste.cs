using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour {

    public Transform[] pathPoints;
    public int currentPath = 0;
    public float reacjDistance = 5f;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Path();

    }

    void Path()
    {
        Vector3 dir = pathPoints[currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;

        transform.Translate(dirNorm * speed * Time.fixedDeltaTime);

        if (dir.magnitude <= reacjDistance)
        {
            currentPath++;
            if (currentPath >= pathPoints.Length)
                currentPath = 0;
        }
    }
}
