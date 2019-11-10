using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NewGameObject {


    private void Start()
    {
        newStart();
    }

    private void Update()
    {
        newUpdate();
    }

    public override void newStart()
    {
        base.newStart();
    }

    public override void newUpdate()
    {
        if (newTransform.x < 4.5)
            newTransform.x -= Time.deltaTime;
        transform.position = new Vector3(newTransform.x, newTransform.y, 0);
    }
}
