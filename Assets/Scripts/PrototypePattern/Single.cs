using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Single : MonoBehaviour {

    static public Single instance;


    private void Awake()
    {
        instance = this;
    }
    public float dor { get; set; }
}
