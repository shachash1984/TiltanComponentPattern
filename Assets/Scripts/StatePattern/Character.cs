using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public Material[] materials;
    private State _state;
    private Rigidbody _rigidbody;
    public void SetState(State s)
    {
        if (_state != null)
            _state.OnStateExit();
        _state = s;
        _state.OnStateEnter(this);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SetState(new StandingState());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            SetState(new JumpingState());
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            SetState(new WalkingState());
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            SetState(new StandingState());
        _state.Action();
    }

    public void SetColor(int index)
    {
        GetComponent<Renderer>().material = materials[index];
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    public void Move(bool right)
    {
        if (right)
            transform.Translate(transform.right * Time.deltaTime * 10);
        else
            transform.Translate(-transform.right * Time.deltaTime * 10);
    }
}
