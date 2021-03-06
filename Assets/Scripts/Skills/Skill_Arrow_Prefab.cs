using UnityEngine;
using System.Collections;
using System;

public class Skill_Arrow_Prefab : MonoBehaviour {
	Rigidbody2D rb;
	private float damage = 5;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(20,0);
		GameObject.Destroy(gameObject,5);
	}

	void OnTriggerEnter2D(Collider2D other){
        if (other.tag.Equals("Wall"))
        {
            GameObject.Destroy(gameObject, 5);
        }
        try
        {

            Health h = other.GetComponent<Health>();
            if (h != null)
            {
                h.Damage(Health.DamageType.None, damage);
                GameObject.Destroy(gameObject, 0);
            }
        }
        catch (Exception) { };
    }
}
