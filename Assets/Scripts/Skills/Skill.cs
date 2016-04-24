using UnityEngine;
using System.Collections;

/// <summary>
/// Skill base class. 
/// </summary>
public abstract class Skill {

	public float coolDown{get; protected set;}
	public string toolTip{get; protected set;}
	public string icon{get; protected set;}

	protected float coolDownTimer;
	protected static ArrayList skills;

	private const float coolDownGlobal = .25f;

	protected abstract void OnCall();

	/// <summary>
	/// Initializes a new instance of the <see cref="Skill"/> class.
	/// </summary>
	/// <param name="coolDown">Cool down.</param>
	/// <param name="toolTip">Tool tip.</param>
	/// <param name="icon">Skill icon.</param>
	public Skill(float coolDown, string toolTip, string icon){
		if(skills == null){
			skills = new ArrayList();
		}
		this.coolDown = coolDown;
		if(coolDown == 0){
			this.coolDown = coolDownGlobal;
		}
		this.toolTip = toolTip;
		this.icon = icon;
	}


	/// <summary>
	/// Adds the skill to the list. Should be called for every
	/// new spell. Used to apply global cooldowns.
	/// </summary>
	/// <param name="mine">Reference to the new skill.</param>
	protected static void AddSkill(Skill mine){
		skills.Add(mine);
	}

	public void Call(){
		if(GetCoolDown()>0.0f){
			return;
		}

		OnCall();
		coolDownTimer = Time.timeSinceLevelLoad+coolDown;

		foreach(Skill s in skills){
			s.TriggerGlobal();
		}
	}

	public void TriggerGlobal(){
		if(GetCoolDown() < coolDownGlobal){
			
			coolDownTimer = Time.timeSinceLevelLoad+coolDownGlobal;
		}
	}


	/// <summary>
	/// Gets the cool down.
	/// </summary>
	/// <returns>The cool down. Is 0 when ready.</returns>
	public float GetCoolDown(){

		float timeUntilCast = coolDownTimer-Time.timeSinceLevelLoad;

		if(timeUntilCast <= 0.0f){
			return 0;
		}else{
			return timeUntilCast;
		}
	}




}
