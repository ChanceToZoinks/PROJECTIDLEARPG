using UnityEngine;
using System.Collections;

public class PlayerGlobalsManager : Singleton<PlayerGlobalsManager>
{
	protected PlayerGlobalsManager() { }

    public GameObject PLAYER_GAME_OBJECT;
    public Rigidbody2D PLAYER_RIGIDBODY;
    public Vector2 PLAYER_VELOCITY;
    public Vector2 PLAYER_JUMP_HEIGHT;
}
