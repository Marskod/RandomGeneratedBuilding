using UnityEngine;
using System.Collections;

public class pongUI : MonoBehaviour {

	public int score; 
	
	void Update()
	{

	}
	
	void OnGUI()
	{
		GUILayout.TextArea("Score: " + score); 
		
		GUI.Window(0, new Rect(Screen.width/8, Screen.height/8, 100,300),highWind,"HIGHSCORES");	
	}
	void highWind(int id)
	{
	}
	
}
