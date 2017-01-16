using UnityEngine;
using System.Collections;

public class PlayerGlobalsManager : Singleton<PlayerGlobalsManager>
{
	protected PlayerGlobalsManager() { }

    public GameObject PLAYER_GAME_OBJECT;
    public Rigidbody2D PLAYER_RIGIDBODY;
    public Vector2 PLAYER_VELOCITY;
    //stuff for jumping
    public Vector2 PLAYER_JUMP_FORCE;
    public bool IS_GROUNDED;
    public Transform GROUND_CHECK;
    public LayerMask GROUND_LAYER;
    public float GROUND_RADIUS;
    public int GRAVITY_VALUE = 10;
}
