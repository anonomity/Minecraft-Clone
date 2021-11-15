using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamLook : MonoBehaviour
{
	[SerializeField]
	public float sensitivity = 100f;

	public GameObject character;

	float xRotation = 0f;


	// Use this for initialization
	void Start()
	{
		character = this.transform.parent.gameObject;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		character.transform.Rotate(Vector3.up * mouseX);
	}
}
