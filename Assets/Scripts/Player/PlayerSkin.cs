using UnityEngine;
using System.Collections;

public class PlayerSkin : MonoBehaviour {

    [SerializeField] private RuntimeAnimatorController[] animators;
    [SerializeField] private int playerID;
    private Animator animator;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();

        if (playerID == 1) {
            animator.runtimeAnimatorController = animators[GameData.Instance.Player1Character];
        } else {
            animator.runtimeAnimatorController = animators[GameData.Instance.Player2Character];
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
