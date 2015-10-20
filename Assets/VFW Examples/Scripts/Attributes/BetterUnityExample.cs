using UnityEngine.Events;
using Vexe.Runtime.Types;
using UnityEngine;

namespace VFWExamples {
    public class BetterUnityExample : BaseBehaviour {

		public class ListDictionary:SerializableDictionary<string,GameObject>{}
        
		[BetterDrawByUnity]
        public float floatField;
        [BetterDrawByUnity]
        public UnityEvent testEvent;

		public ListDictionary testDictionary;

    }
}