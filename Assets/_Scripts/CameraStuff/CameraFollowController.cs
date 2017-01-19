using UnityEngine;
using System.Collections;

public class CameraFollowController : MonoBehaviour
{
    //this class lerps between current camera position and the follow point position
    //the point is intentionally offset a few units in front of the character.
    //this creates an effect where the player sees further ahead of themselves when standing still and a roughly equal distance on either side when moving

    float startingCameraPanSpeed;
    float cameraStartingFov;

    float lerpPathLength;
    float distCoveredInTimeStep;
    float totalLerpPath;
    float newXPosition;
    float newYPosition;

    void Start()
    {
        startingCameraPanSpeed = GlobalsManager.Instance.CAMERA_PAN_SPEED;
        cameraStartingFov = GlobalsManager.Instance.CURRENT_CAMERA.fieldOfView;
    }

    //now adding a bounding box that when the player is inside the camera very slowly drifts to frontward viewing but if the player gets too far ahead the camera moves to him based on the players velocity
    void Update()
    {
        if (!GlobalsManager.Instance.IS_GROUNDED)
        {
            GlobalsManager.Instance.CURRENT_CAMERA.fieldOfView = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA.fieldOfView, GlobalsManager.Instance.CURRENT_CAMERA.fieldOfView + GlobalsManager.Instance.CAMERA_FOV_JUMP_CHANGE, GlobalsManager.Instance.CAMERA_FOV_JUMP_CHANGE / 8.0f * Time.deltaTime);
        }
        else
        {
            GlobalsManager.Instance.CURRENT_CAMERA.fieldOfView = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA.fieldOfView, cameraStartingFov, GlobalsManager.Instance.CAMERA_FOV_JUMP_CHANGE / 15.0f * Time.deltaTime);
        }

        if (GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x >= GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x + GlobalsManager.Instance.CAMERA_SPEEDUP_DISTANCE && GlobalsManager.Instance.PLAYER_RIGIDBODY.velocity.magnitude > 0)
        {
            //increase camera speed if the player is too far away
            GlobalsManager.Instance.CAMERA_PAN_SPEED += 20;

            lerpPathLength = Vector3.Distance(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position);
            distCoveredInTimeStep = Time.deltaTime * GlobalsManager.Instance.CAMERA_PAN_SPEED;
            totalLerpPath = distCoveredInTimeStep / lerpPathLength;
            newXPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.x, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x, totalLerpPath);
            newYPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.y, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.y + GlobalsManager.Instance.CAMERA_Y_OFFSET, totalLerpPath);
            GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position = new Vector3(newXPosition, newYPosition, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.z);
        }
        else
        {
            //once player is back inside the box reset camera speed to original speed
            GlobalsManager.Instance.CAMERA_PAN_SPEED = startingCameraPanSpeed;

            lerpPathLength = Vector3.Distance(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position);
            distCoveredInTimeStep = Time.deltaTime * GlobalsManager.Instance.CAMERA_PAN_SPEED;
            totalLerpPath = distCoveredInTimeStep / lerpPathLength;
            newXPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.x, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.x, totalLerpPath);
            newYPosition = Mathf.Lerp(GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.y, GlobalsManager.Instance.CAMERA_MAIN_FOLLOW_ACTOR.position.y + GlobalsManager.Instance.CAMERA_Y_OFFSET, totalLerpPath);
            GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position = new Vector3(newXPosition, newYPosition, GlobalsManager.Instance.CURRENT_CAMERA_TRANSFORM.position.z);
        }
    }	
}
