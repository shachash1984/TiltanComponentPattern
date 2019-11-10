using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : NewComponent {

    Vector2 velocity;
    Collider[] colliders;
    NewGameObject newGameObject;
    bool isDead = false;
    public bool contact = false;

    private void OnEnable()
    {
        GameManager.GameEventOccured += GameManager_GameEventOccured;
    }

    private void OnDisable()
    {
        GameManager.GameEventOccured -= GameManager_GameEventOccured;
    }

    private void GameManager_GameEventOccured(bool on)
    {
        isDead = true;
    }

    public override void newStart()
    {
        newGameObject = GetComponent<NewGameObject>();
    } 
    public override void newUpdate()
    {
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.RightArrow))
                newGameObject.newTransform.x += 0.1f;
            if (Input.GetKey(KeyCode.LeftArrow))
                newGameObject.newTransform.x -= 0.1f;
            if (Input.GetKey(KeyCode.UpArrow))
                newGameObject.newTransform.y += 0.1f;
            else if (!contact)
                newGameObject.newTransform.y -= 0.1f;
        }
        else
        {
            newGameObject.newTransform.y += 0.1f;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        contact = true;
        Kobi kobi = gameObject.GetComponent<Kobi>();
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if (!kobi.dead)
            {
                kobi.dead = true;
                GameManager.S.PlayerChangedState(kobi.dead);
            }
                
        }
            
    }

    private void OnCollisionStay(Collision collision)
    {
        contact = true;
    }

    public override void newDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        contact = false;
    }

}
