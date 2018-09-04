using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed = 5f;
    public float rotationSpeed = 60f;

    public Camera playerCamera;

    private int selectedSideMark = 0;
    private int selectedFrontMark = 0;

    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Move(Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * selectedSideMark, Space.World);
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * selectedFrontMark);
    }

    private void Move(float value)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * value * movementSpeed);
    }
    public void FrontMarkSelected(int mark)
    {
        selectedFrontMark = mark;
    }

    public void FrontMarkDeselected()
    {
        selectedFrontMark = 0;
    }


    public void SideMarkSelected(int mark)
    {
        selectedSideMark = mark;
    }

    public void SideMarkDeselected()
    {
        selectedSideMark = 0;
    }
}
