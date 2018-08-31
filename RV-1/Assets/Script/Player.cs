using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed = 5f;
    public float rotationSpeed = 60f;

    public Camera playerCamera;
    public float cameraRotationSpeed = 5f;
    [Range(-1f, 0f)]
    public float cameraMinPitch = -0.4f;
    [Range(0f, 1f)]
    public float cameraMaxPitch = 0.4f;
    [Range(-1f, 0f)]
    public float cameraMinYaw = -0.4f;
    [Range(0f, 1f)]
    public float cameraMaxYaw = 0.4f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        Move(Input.GetAxis("Vertical"));
#endif
        RotateCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void Move(float value)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * value * movementSpeed);
    }

    private void RotateBody(float value)
    {
        transform.Rotate(Vector3.up * Time.deltaTime * value * rotationSpeed);
    }

    private void RotateCamera(float xValue, float yValue)
    {
        playerCamera.transform.Rotate(Vector3.right * yValue * -cameraRotationSpeed);
        playerCamera.transform.Rotate(Vector3.up * xValue * cameraRotationSpeed);
        Quaternion cameraQuaternion = playerCamera.transform.localRotation;
        cameraQuaternion.x = Mathf.Clamp(cameraQuaternion.x, cameraMinPitch, cameraMaxPitch);
        cameraQuaternion.y = Mathf.Clamp(cameraQuaternion.y, cameraMinYaw, cameraMaxYaw);

        

        Vector3 cameraEuler = cameraQuaternion.eulerAngles;
        cameraEuler.z = 0f;

        playerCamera.transform.localEulerAngles = cameraEuler;
        if (Mathf.Abs(cameraQuaternion.y) >= 0.65f * cameraMaxYaw)
        {
            RotateBody(cameraQuaternion.y * cameraQuaternion.w);
        }
        if (Mathf.Abs(cameraQuaternion.x) >= 0.5f * cameraMaxPitch)
        {
            Move(cameraQuaternion.x * -cameraQuaternion.w);
        }

    }
}
