using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper : MonoBehaviour
{
   public void RestartButton() 
	{
	 Application.LoadLevel("scene1");
	}
	
	// Update is called once per frame
	public void ExitButton () {
	Application.Quit();
	}
}
