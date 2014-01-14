using UnityEngine;
using System.Collections;

public class spwanWall : MonoBehaviour {

	public GameObject wallSide; 
	public GameObject wallTop;
	public int mapSize = 10;
	public int strightMax = 200;
	
	private float defaultStart = 7.5f; 
	private float zTurnConst = 10.0f;
	
	//initialization
	void Start () {
		
		instTurn(0,18.5f);
		int dirChange = 0;
		float xstart = instStraight(0);
		
		for(int x = 0; x<mapSize; x++)
		{	
			dirChange = Random.Range(1,10);
			
			if(dirChange%2==0)
			{
				xstart = instStraight(xstart);
				Debug.Log("instStraightCalled");
			}
			else{
				Debug.Log("Turncalled");
			}
		}
	}
	
	float instStraight(float endDist)
	{
		int xDist = Random.Range(30, strightMax);
		
		for(float x = endDist; x < xDist; x+=7.5f)
		{
				Debug.Log("in loop x: " + x);
				Instantiate(wallSide, new Vector3(x,3,0), Quaternion.identity);
				Instantiate(wallSide, new Vector3(x,3,6.5f), Quaternion.identity);
				Instantiate(wallTop, new Vector3(x,5.5f,3.25f), Quaternion.AngleAxis(270,Vector3.right));
				endDist = x; 
		}
		Instantiate(wallSide, new Vector3(endDist+=3.75f,3,5), Quaternion.AngleAxis(270,Vector3.up));
		
		//Debug.Log("Forward end: " + endDist);
		return endDist; 
	}

	float instTurn(float endDist, float xLocation)
	{
		int zDist = Random.Range(30, strightMax);
		
		float xOne = xLocation+6.5f, xTwo = xLocation+3.25f;
		
		for(float z = zTurnConst; z < zDist; z+=7.5f)
		{
				Instantiate(wallSide, new Vector3(xLocation,3,z), Quaternion.AngleAxis(270,Vector3.up));
				Instantiate(wallSide, new Vector3(xOne,3,z), Quaternion.AngleAxis(270,Vector3.up));
				Instantiate(wallTop, new Vector3(xTwo,5.5f,z), Quaternion.AngleAxis(270,Vector3.left));
				endDist = z; 
		}
		//Instantiate(wallSide, new Vector3(endDist+=3.75f,3,5), Quaternion.AngleAxis(270,Vector3.up));	
		Debug.Log("Turn end: " + endDist);
		
		return endDist;
	}
}
