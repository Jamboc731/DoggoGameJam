using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Excitable : MonoBehaviour
{
    public int excitedness = 0;
    public Slider excitednessSlider;

    private DoggoController doggo;

    public int difficulty = 1; // multiplier
    private int rate = 1; // rate of increase
    public bool isExploding = false;
    
    private int MAX_EXCITEDNESS = 100; // value of excitedness to reach
    private int tempMax; // plus some random amount

    private int t;
    
    void Start()
    {
        t = 0;
        tempMax = Random.Range(5, 10);
        doggo = GameObject.Find ("Doggo").GetComponent<DoggoController> ();
    }

    void Update()
    {

        t++;
        float fps = Mathf.FloorToInt(1 / Time.deltaTime);
        if ((t % fps) == 0)
        {
            excitedness += rate * difficulty;
            // TODO: excitednessSlider.value = excitedness;
            

            if (excitedness >= MAX_EXCITEDNESS+tempMax)
            {
                excitedness -= Random.Range(40, 90);
                tempMax = Random.Range(5, 10);
                // TODO: Call dog.explode();
                if(doggo.canJump)
                doggo.Jump ();
            }

            t = 0;
            excitednessSlider.value = (float)excitedness/100;
            Debug.Log (string.Format("{0}, {1}", excitedness, excitednessSlider.value));
        }

    }

}
