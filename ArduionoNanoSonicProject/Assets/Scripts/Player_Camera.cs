using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {
	public Transform targetPoint;
	public Rigidbody player;
	Transform myTransform;
	Camera cam;

	
	private void Start() {

		myTransform = transform;
		cam = GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {

		if (targetPoint == null)
		return;

		myTransform.position = targetPoint.position - player.velocity/20f;
		myTransform.rotation = player.rotation;
		cam.fieldOfView = 60f + player.velocity.magnitude/20f;
		InternalLockUpdate();
	}



    private void InternalLockUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
		{
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
