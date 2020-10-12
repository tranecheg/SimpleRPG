using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallTrigger : MonoBehaviour
{
    public float damage;
	public float speed;
	void Start(){
		Destroy(gameObject, 10);
	}
	void Update(){
		transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}
    void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player")){
			col.gameObject.GetComponent<playerStats>().currentLife -= damage;
			Destroy(gameObject);
		}
	}
}
