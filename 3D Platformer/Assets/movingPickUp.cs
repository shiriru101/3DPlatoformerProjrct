using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPickUp : MonoBehaviour
{
    public Transform myPickUp;
    public Transform myStartPoint;
    public Transform myEndPoint;
    public float speed;
    bool isReversing = false;

    // Start is called before the first frame update
    void Start()
    {
        myPickUp.position = myStartPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReversing == false)
        {
            myPickUp.position = Vector3.MoveTowards(myPickUp.position, myEndPoint.position, speed);
            if (myPickUp.position == myEndPoint.position)
            {
                isReversing = true;
            }
        }
        else
        {
            myPickUp.position = Vector3.MoveTowards(myPickUp.position, myStartPoint.position, speed);
            if (myPickUp.position == myStartPoint.position)
            {
                isReversing = false;
            }
        }
    }
}
