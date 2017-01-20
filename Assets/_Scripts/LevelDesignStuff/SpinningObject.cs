using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour {

	void Update()
    {
        this.transform.Rotate(Vector3.back, GlobalsManager.Instance.SPIN_AMOUNT_PER_STEP * Time.deltaTime);
    }
}
