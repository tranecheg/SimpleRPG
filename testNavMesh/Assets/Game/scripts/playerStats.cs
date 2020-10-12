using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{
   public float maxLife = 100;
   public float currentLife = 100;
   public int level = 1;
   public float nextLevelExp = 1000;
   public int currentExp = 0 ;
   public Text txtLevel;
   public Slider expSlider;
   public Slider hpSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = (currentLife/maxLife); 
		expSlider.value = (currentExp/nextLevelExp);
		txtLevel.text = level.ToString();
		if(currentExp>= nextLevelExp){
			level++;
			currentExp = 0;
			nextLevelExp+=500;
		}
		if(currentLife<=0){
			Application.LoadLevel("scene2");
		}
    }
}
