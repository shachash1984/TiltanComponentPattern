using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class EnemyPrototype  {

    public int hp;
    public int damage;
    public abstract EnemyPrototype Clone();
    public override string ToString()
    {
        return string.Format("hp: {0} damage: {1}", hp, damage);
    }
}
