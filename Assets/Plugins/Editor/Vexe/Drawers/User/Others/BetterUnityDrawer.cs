using UnityEditor;
using UnityEngine;
using Vexe.Editor.GUIs;
using Vexe.Editor.Helpers;
using Vexe.Runtime.Types;

namespace Vexe.Editor.Drawers {
    public class BetterUnityDrawer :AttributeDrawer<object, BetterDrawByUnityAttribute> {
        private float _lastHeight;
        private bool _isPressed;
        private bool _foldout;
        private SerializedObject _serializedObject;

        public override void OnGUI() {
            if (member.UnityTarget) {
                if (_serializedObject == null) {
                    _serializedObject = new SerializedObject(member.UnityTarget);
                }
                if (_serializedObject != null) {
                    using (gui.Turtle()){
                        SerializedProperty property = _serializedObject.FindProperty(member.Name);
                        if (property == null) {
                            EditorGUILayout.HelpBox("Member cannot be drawn by Unity: " + member.Name,
                                MessageType.Warning);
                        }
                        else {
                            EditorGUI.BeginChangeCheck();
                            EditorGUILayout.PropertyField(property, true);
                            if (EditorGUI.EndChangeCheck())
                            {
                                _serializedObject.ApplyModifiedProperties();
                                var bb = member.UnityTarget as BetterBehaviour;
                                if (bb != null)
                                    bb.DelayNextDeserialize();
                                else
                                {
                                    var bso = member.UnityTarget as BetterScriptableObject;
                                    if (bso != null)
                                        bso.DelayNextDeserialize();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}