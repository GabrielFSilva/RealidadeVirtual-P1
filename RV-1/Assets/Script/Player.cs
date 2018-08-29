using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed = 5f;
    public float rotationSpeed = 120f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move(Input.GetAxis("Vertical"));
        //Debug.Log(Input.GetAxis("Mouse X"));
        RotateBody(Input.GetAxis("Mouse X"));

    }

    private void Move(float multiplier)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * multiplier * movementSpeed);
    }

    private void RotateBody(float multiplier)
    {
        transform.Rotate(Vector3.up * multiplier * rotationSpeed);
    }
}
