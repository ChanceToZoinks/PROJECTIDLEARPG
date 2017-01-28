using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenuAtStart : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		if (!this.gameObject.activeSelf)
        {
            return;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
	}
}
