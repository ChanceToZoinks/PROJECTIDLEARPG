using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{
    void FixedUpdate()
    {
        PlayerGlobalsManager.Instance.PLAYER_RIGIDBODY.AddForce(new Vector2(22, 12));
    }
}