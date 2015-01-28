using UnityEngine;
using XInputDotNetPure;

public class VibrationTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//GamePad.SetVibration(PlayerIndex.Two,1f,0f);
		GamePad.SetVibration(PlayerIndex.One,1f, 0f); 
	}
}
