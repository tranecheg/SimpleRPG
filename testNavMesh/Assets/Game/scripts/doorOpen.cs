using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public Animation anim;
	public bool isOpen = false;
	 void OnTriggerStay(Collider col){
		 if(col.CompareTag("Player")){
			 if(Input.GetKeyDown(KeyCode.F) && !isOpen){
				anim.Play();
				isOpen = true;				
			 }
		 }
	 }
}
