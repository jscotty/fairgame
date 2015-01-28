using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class ShootBehaviour : MonoBehaviour {

	public GameObject bullet;
	public float counter = 10f;
	private float count;
	private float shakecount;
	private int i;
	public Transform shakeObject;

	bool playerIndexSet = false;
	PlayerIndex playerIndex;
	GamePadState state;
	GamePadState prevState;
	private bool vibrate;
	
	private float vibL = 0f;
	private float vibR = 0f;

	private float tranNum;

	void Update () {
		if (!playerIndexSet || !prevState.IsConnected)
		{
			for (int i = 0; i < 4; ++i)
			{
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState(testPlayerIndex);
				if (testState.IsConnected)
				{
					Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}
		
		prevState = state;
		state = GamePad.GetState(playerIndex);
		//print (state.Triggers.Right);
		if (name == "RacketLeft") {
			tranNum = 2f;
			if(Input.GetButtonDown("A")){
				shoot("normal");
				transform.Translate(new Vector3(-1f,0f,0f)* 10f * Time.deltaTime);
				shakecount = 5;
				vibR = 1f;
			} else {
				vibR -= 0.04f;
			}
			if (vibR <= 0f) {
				vibR = 0f;	
			}
			//GamePad.SetVibration(PlayerIndex.One, 0f, vibR);
		} else if (name == "RacketRight") {
			if(Input.GetButtonDown("A2")){
				tranNum = -2f;
				shoot("normal");
				shakecount = 5;
				transform.Translate(new Vector3(-1f,0f,0f)* 10f * Time.deltaTime);
				vibL = 1f;
			} else {
				vibL -= 0.04f;
			}
			if (vibL <= 0f) {
				vibL = 0f;	
			}
			//GamePad.SetVibration(PlayerIndex.Two, 0f, vibL);
		}

		/* --;
		if (shakecount <= 0) {
			shakecount = 0;	
			shakeObject.transform.position = new Vector3(0f, 0f, -10f);
		} else if( shakecount > 0){
			float randomNmX = Random.Range(-0.2f,0.2f);
			float randomNmY = Random.Range(-0.2f,0.2f);
			float randomNmZ = Random.Range(-9.2f,-10.2f);
			
			shakeObject.transform.position = new Vector3(randomNmX, randomNmY, randomNmZ);
		}*/

		print (vibR);
	}

	private void shoot(string bulletType){
		if (bulletType == "normal") {
			Vibrate(1);
			audio.Play();
			Instantiate(bullet, new Vector3(this.transform.position.x - tranNum,this.transform.position.y,this.transform.position.z), this.transform.rotation);
		}
	}

	private void Vibrate(int length){
		vibrate = true;
		while(i <= 5){
			i++;	
		}

	}
}
