using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyB : EnemyPrototype {

    public float range;

    

    public override EnemyPrototype Clone()
    {
        EnemyB b = new EnemyB();
        b.hp = this.hp;
        b.damage = this.damage;
        b.range = this.range;
        return b;
    }

    public override string ToString()
    {
        Debug.Log(string.Format("{0} range: {1} ", base.ToString(), range));
        return "";
    }
}
