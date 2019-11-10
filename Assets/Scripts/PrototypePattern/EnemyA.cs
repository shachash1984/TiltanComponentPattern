using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyA : EnemyPrototype {

    public float verticalVelocity;

    public override EnemyPrototype Clone()
    {
        EnemyA b = new EnemyA();
        b.hp = this.hp;
        b.damage = this.damage;
        b.verticalVelocity = this.verticalVelocity;
        return b;
    }

    public override string ToString()
    {
        Debug.Log(string.Format("{0} vertical velocity: {1} ", base.ToString(), verticalVelocity));
        return "";
    }
}
