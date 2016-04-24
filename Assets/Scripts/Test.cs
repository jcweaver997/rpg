using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Skill_Arrow arrow = Skill_Arrow.Create();
		arrow.Call();
		Debug.Log(arrow.GetCoolDown());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
