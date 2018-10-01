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
        Vector3 __rot = playerCamera.transform.forward;
        __rot.y = 0f;
        __rot.Normalize();

        // Editor Only movement
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * Input.GetAxis("Horizontal"), Space.World);
        transform.Translate(__rot * Time.deltaTime * Input.GetAxis("Vertical") * movementSpeed, Space.World);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * selectedSideMark, Space.World);
        transform.Translate(__rot * Time.deltaTime * movementSpeed * selectedFrontMark, Space.World);
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
