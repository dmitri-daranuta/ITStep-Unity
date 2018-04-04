using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestList
{
	public string roomName;
	[Multiline]
	//[TextArea(3,10)]
	public string text;
	public Buttons[] buttons;
}

[System.Serializable]
public class Buttons {
	public string action;
	public string text;
}

public class QuestController : MonoBehaviour {
	
	[Header("General settings")]
	public GameObject buttonPrefab;
	public GameObject buttonParent;

	public string currentRoom;
	[Space(10)]

	[Header("Rooms settings")]
	public QuestList[] questList;


	private GameObject panelBtn;
	private GameObject button;

	Dictionary<string, int> states;

	void Awake () {
		states = new Dictionary<string, int> ();

		for (int i = 0; i < questList.Length; i++) {
			if (i == 0) {
				currentRoom = questList [i].roomName;
			}
			states [questList [i].roomName] = i;
		}
	}

	// Use this for initialization
	void Start () {
		SetActions (currentRoom);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void SetActions(string room) {
		int roomId = states [room];	
		for (int i=0; i<questList[roomId].buttons.Length; i++) {
			float tempY = 40f * i;
			string text = questList [roomId].buttons [i].text;
			Debug.Log (text);
			Transform tmpTransform = buttonParent.transform;
			button = Instantiate (buttonPrefab, tmpTransform) as GameObject;
			button.transform.Find ("Text").GetComponent<Text> ().text = text;
			// [ left - bottom ]
			button.GetComponent<RectTransform>().offsetMin = new Vector2(0f, (-15f - tempY));
			// [ right - top ]
			button.GetComponent<RectTransform>().offsetMax = new Vector2(0f, (15f - tempY));
			button.transform.SetParent(buttonParent.transform, false);
		}
	}
}
