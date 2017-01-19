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

    public void AddForceAsFunctionOfVelocity(Rigidbody2D playerRigidbody)
    {
        //the goal is to clamp the force added so it linearly drops based on current velocity. IE at max speed the addforce is adding 0 force
        float currentSpeed = Mathf.Abs(playerRigidbody.velocity.x);
        //get current speed as percentage of max
        float adjustedPercentSpeed = (1 - (currentSpeed / GlobalsManager.Instance.PLAYER_MAX_HORIZONTAL_SPEED));
        //compare the speed to max and if it's over adjust it the opposite direction based on the difference between max speed and current speed
        if (currentSpeed >= GlobalsManager.Instance.PLAYER_MAX_HORIZONTAL_SPEED)
        {
            if (GlobalsManager.Instance.PLAYER_FACING_RIGHT)
            {
                playerRigidbody.AddForce(GlobalsManager.Instance.PLAYER_VELOCITY * adjustedPercentSpeed * -1);
            }
            else
            {
                playerRigidbody.AddForce(GlobalsManager.Instance.PLAYER_VELOCITY * adjustedPercentSpeed);
            }
        }
        else
        {
            if (GlobalsManager.Instance.PLAYER_FACING_RIGHT)
            {
                playerRigidbody.AddForce(GlobalsManager.Instance.PLAYER_VELOCITY);
            }
            else
            {
                playerRigidbody.AddForce(GlobalsManager.Instance.PLAYER_VELOCITY * -1);
            }
        }
    }
}
