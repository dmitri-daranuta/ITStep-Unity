using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatesLogic : MonoBehaviour {

	enum QuestStates {Intro, Room, Window, Door};

	public Text text;

	private QuestStates currentStates;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentStates) {
		case QuestStates.Intro:
			IntroStateUpdate ();
			break;
		}
	}

	private void IntroStateUpdate() {
		
	}
}
