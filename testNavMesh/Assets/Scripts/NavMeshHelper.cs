using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshHelper : MonoBehaviour
{
   public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     GetComponent<NavMeshAgent>().SetDestination(target.position);   
    }
}
