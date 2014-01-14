using UnityEngine;
using System.Collections;

public class Player_test : MonoBehaviour {


	public float pSpeed = 5.0f; 	
	public Transform brick; 
	public Transform bullet; 
	public Transform cam; 
	
	void Start () {
		for(int y = 0; y < 6; y++)
				for(int x = 0; x < 10; x++)
					for(int z = 0; z < 6; z++)
						Instantiate(brick, new Vector3(x,y,z),Quaternion.identity);
	}
	
	void Update () {
		//transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * pSpeed * Time.deltaTime);
		//transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * pSpeed * Time.deltaTime);
		
		if(Input.GetKeyDown("p"))
		{
			Instantiate(bullet, cam.position + 2.0f * cam.forward, cam.rotation);
		}

	}
}
