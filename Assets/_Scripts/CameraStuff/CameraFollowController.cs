using UnityEngine;
using System.Collections;

public class CameraFollowController : MonoBehaviour
{
    //this class lerps between current camera position and the follow point position
    //the point is intentionally offset a few units in front of the character.
    //this creates an effect where the player sees further ahead of themselves when standing still and a roughly equal distance on either side when moving
    void Update()
    {
        //this will eventually become code to give the player more precise control over the camera panning. so when they get closer to the edge of the screen the camera moves faster to keep
        //the forward direction in view.
        //if (Vector3.Distance(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position) < GlobalsManager.Instance.CAMERA_SPEEDUP_DISTANCE)
        //{
        //    float lerpPathLength = Vector3.Distance(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position);
        //    float distCoveredInTimeStep = Time.deltaTime * GlobalsManager.Instance.CAMERA_PAN_SPEED;
        //    float totalLerpPath = distCoveredInTimeStep / lerpPathLength;

        //    float newXPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.x, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x, totalLerpPath);
        //    GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position = new Vector3(newXPosition, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.y, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.z);
        //}
        //else
        //{
        //    float lerpPathLength = Vector3.Distance(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position);
        //    float distCoveredInTimeStep = Time.deltaTime * GlobalsManager.Instance.CAMERA_PAN_SPEED * GlobalsManager.Instance.CAMERA_SPEEDUP_VALUE;
        //    float totalLerpPath = distCoveredInTimeStep / lerpPathLength;

        //    float newXPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.x, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x, totalLerpPath);
        //    GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position = new Vector3(newXPosition, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.y, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.z);
        //}

        float lerpPathLength = Vector3.Distance(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position);
        float distCoveredInTimeStep = Time.deltaTime * GlobalsManager.Instance.CAMERA_PAN_SPEED;
        float totalLerpPath = distCoveredInTimeStep / lerpPathLength;

        float newXPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.x, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x, totalLerpPath);
        float newYPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.y, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.y + GlobalsManager.Instance.CAMERA_Y_OFFSET, totalLerpPath);
        GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position = new Vector3(newXPosition, newYPosition, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.z);
    }	
}
