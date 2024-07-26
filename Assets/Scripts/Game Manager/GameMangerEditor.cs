using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameMangerEditor : Editor 
{
    public bool showFoldout;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager gameManager = (GameManager)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("StateMachine");

        if (gameManager.stateMachine == null) return;
        if (gameManager.stateMachine.CurrentState != null)
        {
            EditorGUILayout.LabelField("Current State: ", gameManager.stateMachine.CurrentState.ToString());
        }

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaliable States");

        if (showFoldout)
        {
            var keys = gameManager.stateMachine.dictionaryState.Keys.ToArray();
            var vals = gameManager.stateMachine.dictionaryState.Values.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
            }
        }
    }
}
