using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTransform
{
    public float x;
    public float y;
    public NewTransform(float _x, float _y)
    {
        x = _x;
        y = _y;
    }
}

public class NewGameObject : MonoBehaviour {

    public static int ID_Counter;
    public int id;
    public NewTransform newTransform;
    public PhysicsComponent physicsComponent;
    public GraphicsComponent graphicsComponent;

    public virtual void newStart()
    {
        id = ID_Counter++;
        newTransform = new NewTransform(transform.position.x, transform.position.y);
    }

    public virtual void newUpdate()
    {
        
    }

    public virtual void newDestroy()
    {
        Destroy(gameObject);
    }
}
