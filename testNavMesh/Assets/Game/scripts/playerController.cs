using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class playerController : MonoBehaviour
{
    public Vector3 targetPos;
	public GameObject ground;
	NavMeshAgent agent;
	Animator anim;
	private bool isPunch = false;
	public Transform currentTarget;
	public float dist;
	
    void Start()
    {
		targetPos = transform.position;
       agent = GetComponent<NavMeshAgent>();
	   
		anim = GetComponent<Animator>();	   
    }

    // Update is called once per frame
    void Update()
    {
		if(currentTarget!=null){
		dist = Vector3.Distance(currentTarget.position, transform.position);
		}
		
       if(Input.GetMouseButtonDown(1) && !isPunch){
		   RaycastHit hit;
		   Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		   if(ground.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)){
			   targetPos = hit.point;
			   //currentTarget = null;
		   }
		  
	   }
	   if(isPunch){
		   transform.LookAt(currentTarget);
		  
	   }
	   if(!isPunch){
		   
		if(agent.velocity==Vector3.zero){
			anim.SetBool("stay", true);
		}
		if(agent.velocity!=Vector3.zero){
			anim.SetBool("stay", false);
		}
	   }
		if(Input.GetKeyDown(KeyCode.Space) && dist<1.3f){
			isPunch = true;
			if(currentTarget!=null){
			currentTarget.GetComponent<enemyController>().Damage(10);
			}
			targetPos = transform.position;
			agent.velocity = Vector3.zero;
			anim.SetBool("punch", true);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			isPunch = false;
			
			anim.SetBool("punch", false);
		}
		
		agent.SetDestination(targetPos);
		
		
    }
}
