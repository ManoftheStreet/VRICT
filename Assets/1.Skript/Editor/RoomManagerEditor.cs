using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsibile for creating and joining rooms.", MessageType.Info);

        RoomManager roomMaager = (RoomManager)target;
        

        if(GUILayout.Button("Join School Room"))
        {
            roomMaager.OnEnterButtonClicked_School();
        }

        if(GUILayout.Button("Join Outdoor Room"))
        {
            roomMaager.OnEnterButtonClicked_Outdoor();
        }
    }

}
