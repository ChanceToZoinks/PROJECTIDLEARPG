using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorFloorTiles : MonoBehaviour {

    //set a timer then every cycle change the color of the square
    float timeSinceColorChange;

    void Start()
    {
        if (GlobalsManager.Instance.GROUND_COLOR_RANDOMNESS)
        {
            timeSinceColorChange = Random.Range(0.0f, GlobalsManager.Instance.FLOOR_SWITCH_RANDOMNESS);
        }
        else
        {
            timeSinceColorChange = 0;
        }
        this.GetComponent<Renderer>().material.color = Toolkit.Instance.PickRandomColor();
    }

    void Update()
    {
        if (Time.time - timeSinceColorChange > GlobalsManager.Instance.FLOOR_COLOR_SWITCH_TIME)
        {
            //Debug.Log("FLOOR COLOR CHANGE");
            this.GetComponent<Renderer>().material.color = Toolkit.Instance.PickRandomColor();
            timeSinceColorChange = Time.time;
        }
    }
}
