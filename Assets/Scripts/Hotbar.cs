using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Hotbar : MonoBehaviour{
	Skill_Arrow arrow = Skill_Arrow.Create();
	KeyCode[] HotbarButtons = {KeyCode.Alpha1};
	Button[] buttons;
	Skill[] skills;
	// Use this for initialization
	void Start () {
		skills = new Skill[1];
		skills[0] = arrow;
		buttons = GetComponentsInChildren<Button>();

		for(int i = 0; i < Mathf.Min(buttons.Length, skills.Length); i++){
			buttons[i].onClick.AddListener(skills[i].Call);
			buttons[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(skills[i].icon);
		}
	
	}

	// Update is called once per frame
	void Update () {
		// Check button presses
		for(int i = 0; i < Mathf.Min(buttons.Length, HotbarButtons.Length); i++){
			if(Input.GetKeyDown(HotbarButtons[i])){
				skills[i].Call();
			}
		}

		// Update displays for cooldowns
		for(int i = 0; i < Mathf.Min(buttons.Length, skills.Length); i++){
			float num = (1-skills[i].GetCoolDown()/skills[i].coolDown);
			buttons[i].GetComponent<Image>().color = new Color(num,num,num);
		}

	}

}
