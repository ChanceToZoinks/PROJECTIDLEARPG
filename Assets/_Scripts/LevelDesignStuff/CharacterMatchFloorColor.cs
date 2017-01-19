using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMatchFloorColor : MonoBehaviour {

	void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(GlobalsManager.Instance.PLAYER_TRANSFORM.position, Vector3.down, out hit, Mathf.Infinity, GlobalsManager.Instance.PLAYER_LAYER))
        {
            //Debug.Log(hit.collider.gameObject.name + " hit");
            Color color = new Color(hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color").r, hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color").g, hit.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color").b, 1);
            GlobalsManager.Instance.PLAYER_MATERIAL.SetColor("_MyColor", color); 
        }
    }
}
