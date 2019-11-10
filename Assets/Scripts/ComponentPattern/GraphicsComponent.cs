using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsComponent : NewComponent {

    public Material deadMaterial;
    public Material liveMaterial;


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
        ChangeMaterial(on);
    }

    public void ChangeMaterial(bool isDead)
    {
        gameObject.GetComponent<Renderer>().material = isDead ? deadMaterial : liveMaterial;
    }
}
