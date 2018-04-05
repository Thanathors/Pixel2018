using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Controller : MonoBehaviour {

    public float Speed =5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GamePadState state = GamePad.GetState(PlayerIndex.One);

        //Right Stick
        if (state.Left.x > 0)
        {
            Debug.Log("Right stick Axis");
        }

        //Button A
        if (state.Pressed(CButton.A))
        {
            Debug.Log("A");
        }

        //Button B
        if (state.Pressed(CButton.B))
        {
            Debug.Log("B");
        }

        //Button X
        if (state.Pressed(CButton.X))
        {
            Debug.Log("X");
        }

        //Button Y
        if (state.Pressed(CButton.Y))
        {
            Debug.Log("Y");
        }

        //Button Back
        if (state.Pressed(CButton.Back))
        {
            Debug.Log("Back");
        }

        //Button Start
        if (state.Pressed(CButton.Start))
        {
            Debug.Log("Start");
        }

        //Left bumper
        if (state.Pressed(CButton.LB))
        {
            Debug.Log("Left Bumper");
        }

        //Right bumper
        if (state.Pressed(CButton.RB))
        {
            Debug.Log("Right Bumper");
        }

        //Left Stick
        if (state.Pressed(CButton.LS))
        {
            Debug.Log("Left Stick");
        }

        //Right Stick
        if (state.Pressed(CButton.RS))
        {
            Debug.Log("Right Stick");
        }

        if (GetComponent<Rigidbody>())
        {
            float moveX = GamePad.GetAxis(CAxis.LX);
            float moveZ = GamePad.GetAxis(CAxis.LY);
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 movement = new Vector3(moveX, 0f, -moveZ);
            rb.AddForce(movement * Speed);
        }
    }
}
