using UnityEngine;

namespace Bllester.TextQuest {
	[System.Serializable]
	public class Nodex {
		public string nodeName = string.Empty;
		[TextArea(3,10)]
		public string nodeDescription = string.Empty;
	}
}