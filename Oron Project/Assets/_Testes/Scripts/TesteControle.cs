using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteControle : MonoBehaviour
{
    private CharacterController _cController;
    public float movSpeed = 1f;
    public float gravity = 10f;
    public float _sensitivity = 1f;

    void Start ()
    {
        _cController = GetComponent<CharacterController>();
	}

	void Update ()
    {
        Movement();

        LookX();
	}

    void Movement()
    {
        float movH = Input.GetAxisRaw("Horizontal");
        float movV = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(movH, 0, movV);
        direction = transform.TransformDirection(direction);
        direction *= movSpeed;
        direction.y -= gravity;
        _cController.Move(direction * Time.deltaTime);
    }

    void LookX()
    {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotationX = transform.localEulerAngles;
        rotationX.y += mouseX * _sensitivity;
        transform.localEulerAngles = rotationX;
    }
}
