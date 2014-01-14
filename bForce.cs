using UnityEngine;
using System.Collections;

public class bForce : MonoBehaviour {
	public float countDown = 2.0f;
	public bool cdActivate = false; 
	public float speed = 100; 
	public int score; 
	public Vector3 velocity; 
	
	
	void Start () {
		rigidbody.AddForce(transform.forward * speed);
	}
	void FixedUpdate()
	{
		Debug.Log(rigidbody.velocity);
	}
	
	void OnCollisionEnter(Collision col)
	{	
		//velocity = Vector3.Reflect(-velocity, transform.forward);
		
		if(col.gameObject.name == "CubeTop")
		{
			Debug.Log("Collided with Top");
			rigidbody.AddForce(col.transform.position += Vector3.back * speed,ForceMode.Force);
			col.transform.position = new Vector3(.95f,.68f,22.61f);
	
		}
		else if(col.gameObject.name == "Player")
		{
			//Debug.Log(Vector3.Distance(col.transform.position,transform.position));
			
			float pz = col.transform.position.z; 
			float py = col.transform.position.y; 
			float px = col.transform.position.x; 

			
			Debug.Log("Collided with palyer");
			//rigidbody.AddForce(transform.forward * speed);	
			//velocity = Quaternion.AngleAxis(-15,Vector3.up) * - velocity; 
			//velocity.z = velocity.z; 
			//rigidbody.AddForce(col.transform.position += Vector3.Reflect(col.transform.position, Vector3.forward) * speed/12.0f);
			
			col.transform.position = new Vector3(px,py,pz); 
			
		}
		else if(col.gameObject.name == "CubeLeft")
		{					
			//rigidbody.AddForce(col.transform.position += Vector3.Reflect(col.transform.position, Vector3.right) * speed/25.0f);


			//rigidbody.AddForce(col.transform.position += Vector3.right * speed,ForceMode.Force);
			//col.transform.position = new Vector3(-44.02f,.68f,-.235f);		
		}
		else if(col.gameObject.name == "CubeRight")
		{		
			//rigidbody.AddForce(col.transform.position += Vector3.Reflect(col.transform.position, Vector3.left) * speed/25.0f);
			//rigidbody.AddForce(col.transform.position += Vector3.left * speed,ForceMode.Force);
			//col.transform.position = new Vector3(44.9f,.68f,.05f);		
		}

		else if(col.gameObject.name == "brick" || col.gameObject.name == "brick(Clone)")
		{ 
			Debug.Log("Collided With Brick");
			Destroy(col.gameObject);
			GameObject UIManager = GameObject.Find("UIManager");
			UIManager.GetComponent<pongUI>().score += 1; 
		}
	}
	
	void Update()
	{
		//transform.Translate(velocity * speed Time.deltaTime, Space.World);
		
		if(cdActivate)
		{
			countDown -= Time.deltaTime;
			if(countDown < 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
