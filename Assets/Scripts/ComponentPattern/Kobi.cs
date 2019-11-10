using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kobi : NewGameObject {

    public GameObject projectilePrefab;
    public bool dead = false;
    
    private void Start()
    {
        newStart();
    }
    public override void newStart()
    {
        
        base.newStart();
        physicsComponent.newStart();
    }

    public void Update()
    {
        newUpdate();
    }
    public override void newUpdate()
    {
        transform.position = new Vector3(newTransform.x, newTransform.y, 0);
        physicsComponent.newUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

    }

    public void Shoot()
    {
        GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
