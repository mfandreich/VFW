using System;
using UnityEngine;
using Vexe.Editor.Helpers;
using UnityEditor;

namespace Vexe.Editor.GUIs {
    public class TurtleBlock : GUIBlock {
        
        public Vector2 startCorrection;
        private Rect _areaRect;
        public Rect realStart;
        public RabbitGUI gui;

        public void Start() {
            //Debug.Log("start block " + _areaRect + " " + width + " " + height + " " + blockMargin);
            if (Event.current.type == EventType.Repaint && _areaRect.width != realStart.width && realStart.width >= 1f)
            {
                _areaRect.width = realStart.width;
                gui.RequestLayout();
                EditorHelper.RepaintAllInspectors();
            }
            if (gui != null) {
                GUILayout.BeginArea(_areaRect);
                GUILayout.BeginVertical(GUILayout.Width((_areaRect.width)));
            }
        }

        public override void Layout(Rect start) {
            
            int nControls = controls.Count;
            if (nControls > 0)
                throw new Exception("Using RabbitGUI inside TurtleBlock not supported.");
            _areaRect.width = realStart.width;
            _areaRect.x     = realStart.x;
            _areaRect.y     = realStart.y;

            x = start.x;
            y = start.y;
            width  = _areaRect.width;
            height = _areaRect.height;
        }

        public override void Dispose() {
            if (gui != null) {
                GUILayout.Label("hidden");
                Rect tempRect = GUILayoutUtility.GetLastRect();
                GUILayout.EndVertical();
                GUILayout.EndArea();
                if (Event.current.type == EventType.Repaint && _areaRect.height != tempRect.y) {
                    _areaRect.height = tempRect.y;
                    gui.RequestLayout();
                    EditorHelper.RepaintAllInspectors();
                }
            }
            base.Dispose();
            //Debug.Log("end block " + _areaRect);
        }

        public override Layout Space(float pxl){
            return Editor.Layout.None;
        }
    }
}