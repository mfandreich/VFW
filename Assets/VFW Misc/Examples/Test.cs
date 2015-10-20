using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using Vexe.Runtime.Types;

[Serializable]
public class A{
	[SerializeField]
	[BetterDrawByUnity]
	public UnityEvent eventField;
}

[Serializable]
public class B{
	[SerializeField]
	public A[] listOfA;
}

public class Test : BaseBehaviour {

	[SerializeField]
	[BetterDrawByUnity]
	public UnityEvent eventField;

	[SerializeField]
	public B[] listOfB;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
