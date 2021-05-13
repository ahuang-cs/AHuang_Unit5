// Inspired by https://github.com/Brackeys/Fruit-Ninja-Replica/blob/master/Fruit%20Ninja%20Replica/Assets/Scripts/Blade.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	bool isCutting = false;

	Vector2 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody rb;
	Camera cam;
	SphereCollider sphereCollider;

	void Start()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
		sphereCollider = GetComponent<SphereCollider>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}

	}

	void UpdateCut()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if (velocity > minCuttingVelocity)
		{
			sphereCollider.enabled = true;
		}
		else
		{
			sphereCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		sphereCollider.enabled = false;
	}

	void StopCutting()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		sphereCollider.enabled = false;
	}
}
