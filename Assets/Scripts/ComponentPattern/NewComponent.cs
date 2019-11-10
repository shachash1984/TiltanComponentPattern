using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewComponent : MonoBehaviour {

	public virtual void newStart()
    {

    }

    public virtual void newUpdate()
    {

    }

    public virtual void newDestroy()
    {
        Destroy(gameObject);
    }
}
