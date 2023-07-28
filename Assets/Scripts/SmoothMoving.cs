using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMoving : MonoBehaviour
{
	public float swayAmount = 0.5f;
	public float maxSwayAmount = 1f;
	public float swaySmooth = 3f;

	private Vector3 initialPosition;

	private void Start()
	{
		initialPosition = transform.localPosition;
	}

	private void Update()
	{
		float inputX = -Input.GetAxis("Mouse X") * swayAmount;
		float inputY = -Input.GetAxis("Mouse Y") * swayAmount;

		// Limit the sway amount
		inputX = Mathf.Clamp(inputX, -maxSwayAmount, maxSwayAmount);
		inputY = Mathf.Clamp(inputY, -maxSwayAmount, maxSwayAmount);

		// Smoothly interpolate the weapon's position back to its initial position
		Vector3 targetPosition = new Vector3(inputX, inputY, 0f);
		transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + targetPosition, Time.deltaTime * swaySmooth);
	}
}
