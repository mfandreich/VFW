using UnityEngine.Events;
using Vexe.Runtime.Types;

namespace VFWExamples {
    public class BetterUnityExample : BaseBehaviour {
        [BetterDrawByUnity]
        public float floatField;
        [BetterDrawByUnity]
        public UnityEvent testEvent;
        //public float test;
    }
}