using System;
using UnityEngine;
using Vexe.Editor.Helpers;
using UnityEditor;

namespace Vexe.Editor.GUIs {
    public class TurtleBlock : GUIBlock {
        
        public Vector2 startCorrection;
        private Rect _areaRect;
        public RabbitGUI gui;

        public void Start() {
            //Debug.Log("start block " + _areaRect + " " + width + " " + height + " " + blockMargin);
            if (gui != null) {
                GUI.BeginGroup(_areaRect);
                Rect inGroup = _areaRect;
                inGroup.x = 0f;
                inGroup.y = 0f;
                GUILayout.BeginArea(inGroup);
            }
        }

        public override void Layout(Rect start) {
            Debug.Log("t in " + start);
            RectOffset blockMargin = data.style.margin;
            int nControls = controls.Count;
            if (nControls > 0)
                throw new Exception("Using RabbitGUI inside TurtleBlock not supported.");
            _areaRect.width = start.width;
            _areaRect.x     = start.x;
            _areaRect.y     = start.y;

            x = start.x;
            y = start.y;
            width  = _areaRect.width;// = _areaRect.width + blockMargin.right;
            height = _areaRect.height;// = _areaRect.height + blockMargin.bottom;
            Debug.Log("out " + _areaRect);
            Debug.Log("out " + width);
        }

        public override void Dispose() {
            if (gui != null) {
                GUILayout.Label("hidden");
                Rect tempRect = GUILayoutUtility.GetLastRect();
                GUILayout.EndArea();
                GUI.EndGroup();
                if (Event.current.type == EventType.Repaint && _areaRect.height != tempRect.y) {
                    _areaRect.height = tempRect.y;
                    gui.RequestLayout();
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