using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdColorChange : MonoBehaviour {

    float timeSinceColorChange;

    void Start()
    {

    }

	void Update()
    {
        if (Time.time - timeSinceColorChange > GlobalsManager.Instance.FLOOR_COLOR_SWITCH_TIME)
        {
            Color color = Toolkit.Instance.PickRandomColor();
            //Debug.Log("FLOOR COLOR CHANGE");
            this.GetComponent<Renderer>().material.SetColor("_Color", color);
            timeSinceColorChange = Time.time;
        }
    }
}
