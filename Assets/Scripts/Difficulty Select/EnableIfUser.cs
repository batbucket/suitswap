using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableIfUser : MonoBehaviour {
    [SerializeField]
    private Button button;

	// Use this for initialization
	private void Update() {
        button.interactable = GameJoltAPI.Instance.HasSignedInUser;
	}
}
