using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bllester.TextQuest {
	[CreateAssetMenu(fileName = "Node", menuName = "Text Quest/Create Node", order = 1)]
	[System.Serializable]
	public class NodeDatabase : ScriptableObject {
		public List<Nodex> nodes = new List<Nodex>();
	}
}