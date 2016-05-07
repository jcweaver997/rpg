using UnityEngine;
using System.Collections;

public class Skill_Arrow : Skill {
	private static Skill_Arrow mine;
	private const string prefabName = "Skill_Arrow_Prefab";


	private Skill_Arrow():base(0,"Shoots an Arrow", "Arrow"){
			mine = this;
			base.AddSkill(mine);
	}


	/// <summary>
	/// Create an Arrow skill script object. Used this way
	/// to prevent multiple instances of same skill being created.
	/// </summary>
	public static Skill_Arrow Create(){
		if(mine == null){
			mine = new Skill_Arrow();
		}
		return mine;
	}


	protected override void OnCall ()
	{
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject.Instantiate(Resources.Load(prefabName),player.transform.position, Quaternion.Euler(new Vector3(0,0,-90)));
	}
}

