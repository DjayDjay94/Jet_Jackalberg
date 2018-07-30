using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemOscillator : MonoBehaviour {

    Vector3 startPosition;

    void Start () {
        startPosition = transform.position;
	}
	
	void Update () {
        float x = startPosition.x;
        float y = 0.5f*Mathf.Sin (Time.timeSinceLevelLoad*2) + startPosition.y;
        float z = startPosition.z;

        transform.position = new Vector3 (x, y, z);
        transform.Rotate(Vector3.up, Time.deltaTime*50, Space.World);
    }
}
