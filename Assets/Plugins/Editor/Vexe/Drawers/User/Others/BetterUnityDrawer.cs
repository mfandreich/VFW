using UnityEngine;
using Vexe.Editor.GUIs;
using Vexe.Editor.Helpers;
using Vexe.Runtime.Types;

namespace Vexe.Editor.Drawers {
    public class BetterUnityDrawer :AttributeDrawer<object, BetterUnityAttribute> {
        private float _lastHeight;
        private bool _isPressed;
        private bool _foldout;

        public override void OnGUI() {
//            using (gui.Vertical()) {
//                using (gui.Indent(10f)) {
//                    _foldout = gui.CustomFoldout("Bingo!", _foldout,Layout.sFit());
//                    if (_foldout) {
//                        using (gui.Indent(8f)) {
//                            gui.Box("", GUIStyles.None, Layout.sHeight(_lastHeight));
//                            Rect boxRect = gui.LastRect;
//                            Rect hiddenRect;
//                            GUILayout.BeginArea(boxRect);
//                            {
//                                GUILayout.Label("Start");
//                                if (GUILayout.Button("Press me"))
//                                {
//                                    _isPressed = !_isPressed;
//                                }
//                                if (_isPressed)
//                                {
//                                    GUILayout.Label("This");
//                                    GUILayout.Label("is");
//                                    GUILayout.Label("inner");
//                                    GUILayout.Label("stuff");
//                                    GUILayout.Label("!!!");
//                                }
//                                GUILayout.Label("End");
//                                GUILayout.Label("");
//                                hiddenRect = GUILayoutUtility.GetLastRect();
//                            }
//                            GUILayout.EndArea();
//
//                            if (Event.current.type == EventType.Repaint)
//                            {
//                                if (_lastHeight != hiddenRect.y)
//                                {
//                                    _lastHeight = hiddenRect.y;
//                                    gui.RequestResetIfRabbit();
//                                    EditorHelper.RepaintAllInspectors();
//                                }
//                            }
//                        }
//                    }
//                }
//            }
            using (VerticalBlock.instance = gui.Vertical()) {
                
            }
            using (gui.Turtle(GUIStyles.Box)) {
                    //Debug.Log("start elements");
                    GUILayout.Label("Start");
                    if (GUILayout.Button("Press me")) {
                        _isPressed = !_isPressed;
                    }
                    if (_isPressed) {
                        GUILayout.Label("This");
                        GUILayout.Label("is");
                        GUILayout.Label("inner");
                        GUILayout.Label("stuff");
                        GUILayout.Label("!!!");
                    }
                    GUILayout.Label("End");
                    //Debug.Log("end elements");
                    //if (Event.current.type == EventType.Repaint) {
                    //    gui.RequestResetIfRabbit();
                    //    EditorHelper.RepaintAllInspectors();
                    //}
                }
            
        }
    }
}