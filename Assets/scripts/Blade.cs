using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	bool isCutting = false;
	Vector3 previousPosition;
	GameObject currentBladeTrail;
	Rigidbody2D rb;
	public Camera cam;
	CircleCollider2D circleCollider;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
		circleCollider.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		} else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}

	}

	void UpdateCut ()
	{
		//Debug.Log ("We are here. Mouse at "+Input.mousePosition);
		Vector3 newPosition = cam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));
		//newPosition.z = 0f;
		//Debug.Log ("Mouse is at "+newPosition);
        rb.position = newPosition;
		//Debug.Log ("Object us at "+transform.position);

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if (velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		} else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform.position, transform.rotation, transform) as GameObject;
		previousPosition = cam.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));
		//previousPosition.z = 0f;
		circleCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}

}
