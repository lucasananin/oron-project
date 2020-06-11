using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCamera : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1f;

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update ()
    {
        //LookX();

        LookY();
	}

    void LookX()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotationX = transform.localEulerAngles;
        rotationX.y += mouseX * _sensitivity;
        transform.localEulerAngles = rotationX;
    }

    void LookY()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rotationY = transform.localEulerAngles;
        rotationY.x -= mouseY * _sensitivity;
        transform.localEulerAngles = rotationY;
    }
}
