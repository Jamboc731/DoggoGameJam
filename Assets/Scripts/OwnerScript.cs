using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnerScript : MonoBehaviour {

    public Slider ownerProgress;
    public int state;

    private void Update ()
    {
        float dTime = Time.deltaTime;
        ownerProgress.value +=  dTime / 150;

        if (ownerProgress.value < 50 * dTime)
            state = 1;
        else if (ownerProgress.value < 100)
            state = 2;
        else
            state = 3;
            

    }

}
