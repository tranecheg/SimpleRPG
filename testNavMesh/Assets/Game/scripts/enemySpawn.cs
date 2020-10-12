using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemyPref;
	public int enemyCount = 0;
	public GameObject[] npcs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		npcs = GameObject.FindGameObjectsWithTag("enemy");
		enemyCount = npcs.Length;
      if(enemyCount==0){
		Spawn();
	  }  
    }
	 void Spawn() {
     for (int i = 0; i < 6; i++) {
          GameObject enemy = Instantiate(enemyPref, new Vector3(Random.Range(7, 12),transform.position.y,Random.Range(2, 7)) , Quaternion.identity);
     }
 }
}
