using UnityEngine;
using System.Collections;

public class CameraFollowController : MonoBehaviour
{
    //this class lerps between current camera position and the follow point position
    //the point is intentionally offset a few units in front of the character.
    //this creates an effect where the player sees further ahead of themselves when standing still and a roughly equal distance on either side when moving
    void Update()
    {
        float lerpPathLength = Vector3.Distance(this.transform.position, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position);
        float distCoveredInTimeStep = Time.deltaTime * GlobalsManager.Instance.CAMERA_PAN_SPEED;
        float totalLerpPath = distCoveredInTimeStep / lerpPathLength;

        float newXPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.x, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x, totalLerpPath);
        GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position = new Vector3(newXPosition, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.y, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.z);
    }	
}
