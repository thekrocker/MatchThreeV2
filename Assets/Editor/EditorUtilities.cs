using UnityEditor;
using UnityEngine;

#if  UNITY_EDITOR

namespace MatchThree.Editor
{
    public static class EditorUtilities
    {
        [MenuItem("Tools/Toggle Lock Inspector %q")]
        private static void ToggleInspectorLock()
        {
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
            ActiveEditorTracker.sharedTracker.activeEditors[0].Repaint();
        }
        
        [MenuItem("Tools/Reset Transform &r")]
        private static void ResetTransform()
        {
            var selection = Selection.gameObjects;
            if (selection.Length < 1) return;
            
            foreach (GameObject go in selection)
            {
                go.transform.localPosition = Vector3.zero;
                go.transform.localRotation = Quaternion.Euler(Vector3.zero);
                go.transform.localScale = Vector3.one;
            }
        }

    }
}

#endif