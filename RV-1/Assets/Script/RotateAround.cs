using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public Vector3 rotationSpeed = new Vector3(0f, 120f, 0f);

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    public void ChangeRotationSpeed()
    {
        rotationSpeed *= -1f;
    }
}
