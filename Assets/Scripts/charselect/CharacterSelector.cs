using UnityEngine;
using System.Collections;

public class CharacterSelector:MonoBehaviour {

    public GameObject startButton;
    private bool bothSelected = false;
    private bool player1 = true;


    /*
    [SerializeField] private Texture2D[] characters;
	[SerializeField] private GUIStyle characterSelectorStyle;
	[SerializeField] private GUIStyle startButtonStyle;

	private MainMenu mainMenu;
		
	private int currentPlayer = 1;

	private bool bothSelected;
	private bool opened;

	void Start() {
		mainMenu = GetComponent<MainMenu>();
	}

	void OnGUI() {
		if(!opened)
			return;

		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3((float)Screen.width / 1920.0f, (float)Screen.height / 1080.0f, 1));

		int i = 0;

		for(int y = -1; y < 2; y++) {
			for(int x = -1; x < 2; x++) {
				characterSelectorStyle.normal.background = characters[i];

				if(GUI.Button(new Rect(810 + (x * 250), 390 + (y * 250) , 300, 300), new GUIContent(i.ToString()), characterSelectorStyle)) {
					if(!bothSelected) {
						switch(currentPlayer) {
						case 1:
							GameData.Instance.Player1Character = i;
							currentPlayer = 2;
							break;
						case 2:
							GameData.Instance.Player2Character = i;
							bothSelected = true;
							break;
						}
					}
				}

				i++;
			}
		}

		if(bothSelected)
			if(GUI.Button(new Rect(1060, 1000, 200, 50), new GUIContent("Start Game"), startButtonStyle))
				Application.LoadLevel("LevelSelectionScreen");

		if(GUI.Button(new Rect(760, 1000, 200, 50), new GUIContent("Back"), startButtonStyle))
			mainMenu.Open();
	}

	public void Open() {
		opened = true;

		mainMenu.Close();
	}

	public void Close() {
		opened = false;
	}
    */

    public void SelectedChar(int charNum) {
        if (player1) {
            GameData.Instance.Player1Character = charNum;
            player1 = false;
            Debug.Log("Player 1 selected: " + charNum);
        } else {
            GameData.Instance.Player2Character = charNum;
            bothSelected = true;
            Debug.Log("Player 2 selected: " + charNum);
        }
    }

    void FixedUpdate() {
        if (Application.loadedLevelName != "CharSelect") {
            Destroy(gameObject);
            return;
        }

        if (bothSelected) {
            startButton.SetActive(true);
        } else {
            startButton.SetActive(false);
        }
    }

}