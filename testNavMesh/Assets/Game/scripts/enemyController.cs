using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 
using UnityEngine.UI; 

public class enemyController : MonoBehaviour
{
    public float DistanceToFire, DistanceToWalk, DistanceToBite;
	public float delayFire;
	public float delayBite;
	public float delayBetweenAnim;
	public GameObject player;
	NavMeshAgent agent;
	public Animator anim;
	public float currentDistance;
	public bool isFire, isWalk, isBite;
	public GameObject EnemyHP;
	
	public float maxHP = 100;
	public float currentHP = 100;
	
	public Vector3 offset;
	public enemyHP hpSlider;
	public GameObject fireBall;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
		GameObject hp = Instantiate(EnemyHP, Vector3.zero, Quaternion.identity) as GameObject;
		hp.transform.SetParent(GameObject.Find("Canvas").transform);
		hpSlider = hp.GetComponent<enemyHP>();
		hp.transform.SetAsFirstSibling();
		hp.GetComponent<enemyHP>().maxHP = maxHP;
		hp.GetComponent<enemyHP>().currentHP = currentHP;
		hp.GetComponent<enemyHP>().enemy = gameObject;
		hp.GetComponent<enemyHP>().offset = offset;
    }

    // Update is called once per frame
    void Update()
    {
		if(hpSlider.currentHP <= 0){
			
			agent.enabled = false;
			
			anim.enabled = false;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().AddForce(Vector3.right*300);
			transform.gameObject.tag = "Untagged";
			player.GetComponent<playerStats>().currentExp +=250;
			Destroy(hpSlider.gameObject);
			
			//Destroy(gameObject);
			this.enabled = false;
			
			
			
		}
		else{
			
		
       float distance = Vector3.Distance(player.transform.position, transform.position); 
	   currentDistance = distance;
	   if(distance > DistanceToFire){
		   return;
	   }
	   if(distance < DistanceToFire && distance > DistanceToWalk){
			 transform.LookAt(player.transform);
			 if(!isFire){
				 StartCoroutine(Fire());
			 }
	   }
	   if(distance < DistanceToWalk && distance>DistanceToBite){
		   agent.SetDestination(player.transform.position);
			anim.SetBool("isFire", false);
			anim.SetBool("isBite", false);
		   
	   }
	   if(distance < DistanceToWalk && distance<DistanceToBite){
		   
		 agent.SetDestination(player.transform.position);
		  transform.LookAt(player.transform);
			    if(!isBite){
				 StartCoroutine(Bite());
			 }
		   
	   }
	   }
	   
	   
    }
	void Shooting(){
		GameObject fb = Instantiate(fireBall, transform.position, transform.rotation) as GameObject;
	}
	IEnumerator Fire(){
		isFire = true;
		
		anim.SetBool("isFire", true);
		yield return new WaitForSeconds(delayFire/2);
		Shooting();
		
		yield return new WaitForSeconds(delayFire/2);
		anim.SetBool("isFire", false);
		yield return new WaitForSeconds(delayBetweenAnim);
		isFire = false;
	}
	IEnumerator Bite(){
		isBite = true;
		
		anim.SetBool("isBite", true);
		player.GetComponent<playerStats>().currentLife -=5;
		yield return new WaitForSeconds(delayBite);
		anim.SetBool("isBite", false);
		yield return new WaitForSeconds(delayBetweenAnim);
		isBite = false;
	}
	void OnMouseDown(){
		if(Input.GetMouseButtonDown(0)){
			player.GetComponent<playerController>().currentTarget = gameObject.transform;
		}
	}
	public void Damage(int dmg){
		hpSlider.currentHP = hpSlider.currentHP - dmg;
		
	}
}
