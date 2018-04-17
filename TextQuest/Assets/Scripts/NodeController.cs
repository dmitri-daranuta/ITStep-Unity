using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class NodeList {
	//public Nodes node;
	public NodeActions action;
}

public class NodeController : MonoBehaviour {

	[Header("General Settings")]
	//public Nodes defaultNode;
	public NodeActions defaultActions;
	public Text displayText;
	[Range(.001f, .5f)]
	public float typingSpeed;

	[Header("Node List")]
	public NodeList[] nodeList;

	void Start () {
		//StartCoroutine (Type ());
	}

	void Update () {
		
	}

//	IEnumerator Type() {
//		foreach (char letter in defaultNode.text.ToCharArray()) {
//			displayText.text += letter;
//			yield return new WaitForSeconds (typingSpeed);
//		}
//	}
}
