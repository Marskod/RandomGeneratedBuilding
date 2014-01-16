using UnityEngine;
using System.Collections;

public class shipMovement : MonoBehaviour {
	
	public float shipSpeed  = 5; 
	public float rotationSpeed = 5;
	
	private float mouseposX; 
	private Vector3 rayHitWorldPosition; 
	
	void Update () {
		
		float inputx = Input.GetAxis("Horizontal");
		float inputy = Input.GetAxis("Vertical");
		
		float mousex = Input.GetAxis("Mouse X");
		float mousey = Input.GetAxis("Mouse Y"); 

		GameObject pSystem = GameObject.Find("speedFX"); 
		pSystem.particleSystem.startSpeed = shipSpeed * 2;
		pSystem.particleSystem.emissionRate = shipSpeed * 2;
		
		transform.Translate(Vector3.forward * shipSpeed * Time.deltaTime);
		//transform.Rotate(Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
		//transform.Rotate(Vector3.Angle(Vector3)*inputx*rotationSpeed*Time.deltaTime,Space.World);
		
		//Rotation(mousex,mousey,inputx);
		mouseEdge();
		mouseMovement();
		
		
		if(Input.GetKeyDown("space"))
		{
			shipSpeed += 20; 
		}
	}
	
	void OnGUI()
	{
		//GUILayout.Label(shipSpeed);
	}
	
	void mouseEdge()
	{
		if(Input.mousePosition.x > Screen.width - 50)
		{ 
     		 transform.Rotate(0, (rotationSpeed/3) * Time.deltaTime, 0 * Time.deltaTime, Space.World); 
		}
		if(Input.mousePosition.x < 50)
		{
			 transform.Rotate(0, -(rotationSpeed/3) * Time.deltaTime, 0 * Time.deltaTime, Space.World); //The X-rotation turns the plane - the Z-rotation tilts it 
		} 
  	    if(Input.mousePosition.y > Screen.height - 50)
		{ 
     		 transform.Rotate(-45 * Time.deltaTime, 0, 0); 
		} 
   		if(Input.mousePosition.y < 50)
		{ 
      		transform.Rotate(45  *  Time.deltaTime, 0, 0); 
    	} 
	}
	
	void mouseMovement()
	{
		if(Input.GetAxis("Mouse X") > 0.0 && Input.GetAxis("Mouse X") < Screen.width - 50)
		{ 
     		 transform.Rotate(0, (rotationSpeed) * Time.deltaTime, 0 * Time.deltaTime, Space.World); 
		}
		if(Input.GetAxis("Mouse X") < 0.0)
		{
			 transform.Rotate(0, -(rotationSpeed) * Time.deltaTime, 0 * Time.deltaTime, Space.World); //The X-rotation turns the plane - the Z-rotation tilts it 
		} 
  	    if(Input.GetAxis("Mouse Y") > 0.0 && Input.GetAxis("Mouse Y") < Screen.height - 50)
		{ 
     		 transform.Rotate(-45 * Time.deltaTime, 0, 0); 
		} 
   		if(Input.GetAxis("Mouse Y") < 0.0)
		{ 
      		transform.Rotate(45  *  Time.deltaTime, 0, 0); 
    	} 
	}
	
	void Rotation(float horizontal, float vertical, float z)
	{
		Vector3 rDirection = new Vector3(vertical, horizontal, z);
		
		//Quaternion targetRotation = Quaternion.LookRotation(rDirection, Vector3.right);
		//Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, rotationSpeed * Time.deltaTime);
		
		Quaternion dr = Quaternion.Euler(rDirection * rotationSpeed * Time.deltaTime);
		rigidbody.MoveRotation(dr * rigidbody.rotation);
	}
}
