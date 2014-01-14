using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {

	public Transform sObj;
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Daylight Water")
		{
			Instantiate(sObj, transform.position - .4f * transform.up, Quaternion.identity);
		}
	}
	
}
