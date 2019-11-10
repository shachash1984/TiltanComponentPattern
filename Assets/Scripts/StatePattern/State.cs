using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class State  {

    protected Character _character;
    public abstract void Action();
    public virtual void OnStateEnter(Character c)
    {
        _character = c;
    }
    public abstract void OnStateExit();
    
}

public class StandingState : State
{
    public override void Action()
    {
        Debug.Log("Standing");
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Standing");
    }

    public override void OnStateEnter(Character c)
    {
        Debug.Log("Enter Standing");
        base.OnStateEnter(c);
        c.SetColor(0);
    }

}

public class WalkingState : State
{
    public override void Action()
    {
        Debug.Log("Walking");
        _character.Move(Input.GetAxis("Horizontal") > 0);
    }

    public override void OnStateEnter(Character c)
    {
        Debug.Log("Enter Walking");
        base.OnStateEnter(c);
        c.SetColor(1);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exit Walking");
    }
}

public class JumpingState : State
{
    public override void Action()
    {
        Debug.Log("Jumping");
        
    }

    public override void OnStateEnter(Character c)
    {
        Debug.Log("Enter Jumping");
        
        base.OnStateEnter(c);
        _character.Jump();
        c.SetColor(2);
    }

    public override void OnStateExit()
    {

        Debug.Log("Exit Jumping");
    }
}
