using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyC : EnemyPrototype
{

    public float horizontalVelocity;
    public override EnemyPrototype Clone()
    {
        EnemyC b = new EnemyC();
        b.hp = this.hp;
        b.damage = this.damage;
        b.horizontalVelocity = this.horizontalVelocity;
        return b;
    }

    public override string ToString()
    {
        Debug.Log(string.Format("{0} horizontal velocity: {1} ", base.ToString(), horizontalVelocity));
        return "";
    }
}
