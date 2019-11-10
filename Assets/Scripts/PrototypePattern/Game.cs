using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public EnemyA a;
    public EnemyB b;
    public EnemyC c;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyA aa = a.Clone() as EnemyA;
            EnemyB bb = b.Clone() as EnemyB;
            EnemyC cc = c.Clone() as EnemyC;

            aa.ToString();
            bb.ToString();
            cc.ToString();
        }
        Single.instance.dor = 0;
	}
}
