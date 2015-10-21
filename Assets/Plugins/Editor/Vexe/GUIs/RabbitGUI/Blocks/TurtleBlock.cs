using System;
using UnityEngine;
using Vexe.Editor.Helpers;
using UnityEditor;

namespace Vexe.Editor.GUIs {
    public class TurtleBlock : GUIBlock {
        
		public RabbitGUI gui;
		private float _realHeight;
		private float _realWidht;
		private Rect _areaRect;

		public float RealHeight{
			get{return _realHeight;}
		}

		public float RealWidth{
			get{return _realWidht;}
		}

		public Rect AreaRect{			 
			set{_areaRect = value;}
		}

        public void Start() {            
            if (gui != null) {
				GUILayout.BeginArea(_areaRect);
				_realWidht = _areaRect.width;
                GUILayout.BeginVertical(GUILayout.Width(_realWidht));
            }
        }

        public override void Layout(Rect start) {
            x = start.x;
            y = start.y;
            width  = 0f;
            height = 0f;
        }

        public override void Dispose() {
            if (gui != null) {
                GUILayout.Label("hidden");
                Rect tempRect = GUILayoutUtility.GetLastRect();
                GUILayout.EndVertical();
                GUILayout.EndArea();
                if (Event.current.type == EventType.Repaint && _areaRect.height != tempRect.y) {
                    _realHeight = tempRect.y;                    
                }
            }
            base.Dispose();
            
        }

        public override Layout Space(float pxl){
            return Editor.Layout.None;
        }
    }
}