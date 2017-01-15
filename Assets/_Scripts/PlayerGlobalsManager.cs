using UnityEngine;
using System.Collections;

public class PlayerGlobalsManager : Singleton<PlayerGlobalsManager>
{
	protected PlayerGlobalsManager() { }

    public GameObject PLAYER_GAME_OBJECT;
    public Rigidbody2D PLAYER_RIGIDBODY;
}
