using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class YMover : MonoBehaviour {

    // Awake() runs before Start(). Use it to get listeners ready as early as possible.
    private void Awake()
    {
        MovingGameModel.OnPositionsUpdated += PositionsUpdatedHandler;
    }
    // Use this for initialization

    private void PositionsUpdatedHandler (Dictionary<string, float> positions)
    {
        //Debug.Log(gameObject.name + " heard about new position: " + positions[gameObject.name]);
        
        // Determine my new y
        float myNewY = positions[gameObject.name];
        // store my existing x and z;
        float myX = transform.localPosition.x;
        float myZ = transform.localPosition.z;

        // my position = my x, the new y, my z;
        // If I could just change y I would, but using localPosition requires the whole vector.
        transform.localPosition = new Vector3(myX, myNewY, myZ);
    }
}
