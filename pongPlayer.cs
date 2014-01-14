using UnityEngine;
using System.Collections;

public class pongPlayer : MonoBehaviour {
	
	public float pSpeed = 5.0f; 
	public bool start = false; 
	public Transform ball; 
	public Transform brick; 
	
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(.4f,.66f,-18.1f);
		
		for(int x = -34; x < 34; x+=4)
			for(int z = 1; z < 16; z+=4)
				Instantiate(brick, new Vector3(x,.6f,z),Quaternion.identity);
	}
	
	void OnGUI()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * pSpeed * Time.deltaTime);
		
		if(start == false)
		{
			if(Input.GetKeyDown("space"))
			{
				start = true; 
				Instantiate(ball, transform.position + 2.0f * transform.forward, Quaternion.identity); 
			}
		}
	}
}
