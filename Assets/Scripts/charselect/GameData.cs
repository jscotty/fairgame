using UnityEngine;
using System.Collections;

public class GameData:Singleton<GameData> {
	[SerializeField] private int player1Character;
	[SerializeField] private int player2Character;

	void Start() {
		DontDestroyOnLoad(gameObject);
	}

	public int Player1Character {
		set { player1Character = value; }
		get { return player1Character; }
	}

	public int Player2Character {
		set { player2Character = value; }
		get { return player2Character; }
	}
}
