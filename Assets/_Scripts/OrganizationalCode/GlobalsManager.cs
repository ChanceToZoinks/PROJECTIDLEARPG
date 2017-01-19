using UnityEngine;
using System.Collections.Generic;

public class GlobalsManager : Singleton<GlobalsManager>
{
    //this class holds any reference that will need to be called over and over by different
    //classes used in different areas of the code. this eliminates the need to update references when they're changed.
    //just update the value here and all the references elsewhere get updated.
	protected GlobalsManager() { }

    public GameObject PLAYER_GAME_OBJECT;
    public Transform PLAYER_TRANSFORM;
    public Rigidbody2D PLAYER_RIGIDBODY;
    public Vector2 PLAYER_VELOCITY;
    public float PLAYER_MAX_HORIZONTAL_SPEED;
    public bool PLAYER_FACING_RIGHT = true; // false is left, right is default
    public Material PLAYER_MATERIAL;
    public LayerMask PLAYER_LAYER;
    //stuff for jumping
    public Vector2 PLAYER_JUMP_FORCE;
    public bool IS_GROUNDED;
    public Transform GROUND_CHECK;
    public LayerMask GROUND_LAYER;
    public float GROUND_RADIUS;
    public int GRAVITY_VALUE = 10;
    //stuff for camera
    public Camera CURRENT_CAMERA;
    public Transform CURRENT_CAMERA_TRANSFORM;
    public Transform CAMERA_MAIN_FOLLOW_ACTOR;
    public float CAMERA_PAN_SPEED;
    public float CAMERA_SPEEDUP_DISTANCE;
    public float CAMERA_Y_OFFSET;
    public float CAMERA_FOV_JUMP_CHANGE;
    //stuff for level
    //public Material FLOOR_TILE_MATERIAL;
    public float FLOOR_COLOR_SWITCH_TIME;
    public float FLOOR_SWITCH_RANDOMNESS;
    public bool GROUND_COLOR_RANDOMNESS;
    public Color[] FLOOR_COLOR_ARRAY;
}
