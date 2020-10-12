using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHP : MonoBehaviour
{
    public float maxHP = 100;
	public float currentHP = 100;
	public GameObject enemy;
	public Vector3 offset;
    void Start()
    {
        maxHP = maxHP*GameObject.Find("player").GetComponent<playerStats>().level;
		currentHP = currentHP*GameObject.Find("player").GetComponent<playerStats>().level;
    }

    // Update is called once per frame
    void Update()
    {
		
      GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position+offset );
	GetComponent<Slider>().value = (currentHP/maxHP);	  
    }
}
