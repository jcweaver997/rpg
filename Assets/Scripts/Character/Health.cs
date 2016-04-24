using UnityEngine;
public class Health{


    public enum DamageType{
        None, Fire, Water, Rock, Ice, Lightning, Arcane, Holy, Undead
    }

    public delegate void Empty();
    private Empty onDeath;

    public delegate void DamageListener(DamageType dt, out float dmg);
    private DamageListener damageListener;

    public float health { get; set; }
    public DamageType healthType { get; private set; }
    public bool team { get; set; }
    public Transform transform { get; private set; }

    public Health(bool own, float health, Transform transform, DamageType healthType = DamageType.None)
    {
        
        this.health = health;
        this.healthType = healthType;
        this.team = own;
        this.transform = transform;
        Global.healthObjects.Add(this);
    }

    ~Health()
    {

    }

    public void SetDamageListener(DamageListener dl)
    {
        damageListener = dl;
    }

    public void SetDeathListener(Empty death)
    {
        onDeath = death;
    }

    public void Damage(DamageType dt, float dmg)
    {

        if (damageListener != null){ damageListener(dt, out dmg); }

        health -= dmg;

        if (health <=0)
        {
            if (onDeath != null) { onDeath(); }
            Global.healthObjects.Remove(this);
        }

    }
}
