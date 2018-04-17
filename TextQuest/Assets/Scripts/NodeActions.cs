using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NodeActions", menuName = "Text Quest/Create Node Actions", order = 2	)]
public class NodeActions : ScriptableObject {
	public Actions[] actions;
}

[System.Serializable]
public class Actions {
	//public Nodes action;
	public string text;
}