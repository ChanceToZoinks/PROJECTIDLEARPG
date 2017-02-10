using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    [SerializeField]
    private BezierSpline bezierSpline;
    [SerializeField]
    private Rigidbody player3DRigidbody;
    private Vector3 directionToApplyForce;

    public float value;

    void Update()
    {
        player3DRigidbody.gameObject.transform.rotation = Quaternion.LookRotation(bezierSpline.GetDirection(value));
    }

	void FixedUpdate()
    {
        //directionToApplyForce = -player3DRigidbody.gameObject.transform.up;
        Debug.Log(directionToApplyForce);
        ApplyGravity();
    }

    void ApplyGravity()
    {
        player3DRigidbody.AddForce(directionToApplyForce * GlobalsManager.Instance.GRAVITY_VALUE, ForceMode.Force);
    }
}
