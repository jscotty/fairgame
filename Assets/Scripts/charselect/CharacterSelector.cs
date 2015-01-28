using UnityEngine;
using System.Collections;

public class CharacterSelector:MonoBehaviour {

    public GameObject startButton;
    private bool bothSelected = false;
    private bool player1 = true;

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