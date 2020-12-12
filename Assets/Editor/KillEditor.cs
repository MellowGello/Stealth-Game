using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerKill))]
public class KillEditor : Editor
{
    private void OnSceneGUI()
    {
        PlayerKill ScriptKill = (PlayerKill)target;

        Handles.color = Color.white;
        Handles.DrawWireArc(ScriptKill.transform.position, Vector3.up, Vector3.forward, 360, ScriptKill.Radius);
    }
}
