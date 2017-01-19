using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolkit : Singleton<Toolkit> {

    //this class holds various methods and functions i thought i might use, need to focus on trimming waste
	protected Toolkit() { }

    public Color PickRandomColor()
    {
        return GlobalsManager.Instance.FLOOR_COLOR_ARRAY[Random.Range(0, GlobalsManager.Instance.FLOOR_COLOR_ARRAY.Length)];
    }

    public float RandomSinValue()
    {
        float randomSinValue = Mathf.Sin(Random.Range(0.0f, Mathf.PI * 2.0f));
        return randomSinValue;
    }
}
