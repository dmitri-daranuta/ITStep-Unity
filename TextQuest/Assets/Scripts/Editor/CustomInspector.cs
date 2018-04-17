using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Bllester.TextQuest.Editors {
	[CustomEditor(typeof(NodeDatabase))]
	public class CustomInspector : Editor {
		NodeDatabase db;

		void OnEnable() {
			db = (NodeDatabase)target;
		}

		public override void OnInspectorGUI() {
			GUILayout.BeginVertical ("box");
			GUILayout.Space (5);
			GUILayout.BeginHorizontal ();
			GUILayout.Space (10);

			GUILayout.Label ("Total nodes: " + db.nodes.Count);
			if (GUILayout.Button ("Add Node")) {
				AddNode ();
			}

			GUILayout.Space (10);
			GUILayout.EndHorizontal ();
			GUILayout.Space (5);
			GUILayout.EndVertical ();
			GUILayout.Space (20);

			for (int i = 0; i < db.nodes.Count; i++) {
				GUILayout.BeginHorizontal ();

				db.nodes[i].nodeName = GUILayout.TextField (db.nodes [i].nodeName, GUILayout.Width (100));
				db.nodes[i].nodeDescription = GUILayout.TextField (db.nodes [i].nodeDescription, GUILayout.Height(50));
				if (GUILayout.Button("X", GUILayout.Width(20))) {
					RemoveNode(i);
					return;
				}

				GUILayout.EndHorizontal ();
			}
		}

		void AddNode() {
			db.nodes.Add (new Nodex());
		}

		void RemoveNode(int index) {
			db.nodes.RemoveAt (index);
		}
	}
}
