using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Arsenal))]
public class ArsenalEditor : Editor {

	override public void OnInspectorGUI()
	{
		var myScript = target as Arsenal;

		SerializedProperty weps = serializedObject.FindProperty ("weaponry");
		EditorGUI.BeginChangeCheck ();
		EditorGUILayout.PropertyField (weps, true);
		if (EditorGUI.EndChangeCheck ()) {
			serializedObject.ApplyModifiedProperties ();
		}
		using (var group3 = new EditorGUILayout.FadeGroupScope (Convert.ToSingle (myScript.isEnemy))) {
			if (group3.visible == false) {
				SerializedProperty ammo = serializedObject.FindProperty ("ammoPool");
				EditorGUI.BeginChangeCheck ();
				EditorGUILayout.PropertyField (ammo, true);
				if (EditorGUI.EndChangeCheck ()) {
					serializedObject.ApplyModifiedProperties ();
				}
			}

		myScript.isEnemy = EditorGUILayout.Toggle ("Is Enemy", myScript.isEnemy);

		using (var group = new EditorGUILayout.FadeGroupScope (Convert.ToSingle (myScript.isEnemy))) {
			if (group.visible == false) {
				SerializedProperty display = serializedObject.FindProperty ("display");
				EditorGUI.BeginChangeCheck ();
				EditorGUILayout.PropertyField (display, true);
				if (EditorGUI.EndChangeCheck ()) {
					serializedObject.ApplyModifiedProperties ();
				}
			}
			else if (group.visible == true) {
				myScript.usesVector = EditorGUILayout.Toggle ("Uses Vector", myScript.usesVector);
				using (var group2 = new EditorGUILayout.FadeGroupScope (Convert.ToSingle (myScript.usesVector))) {
					if (group2.visible == false) {
						myScript.timerDelay = EditorGUILayout.FloatField ("Timer", myScript.timerDelay);
					} else if (group2.visible == true) {
						myScript.triggerVector = EditorGUILayout.Vector2Field ("Trigger Vector", myScript.triggerVector);
					}

			}
		}
			
	}
}
}
}
