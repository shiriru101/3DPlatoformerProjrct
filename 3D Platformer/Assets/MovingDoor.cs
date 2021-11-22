using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    public bool isOpen = false;
    public Transform Door;
    public Transform StartPoint;
    public Transform EndPoint;

    // Start is called before the first frame update
    void Start()
    {
        Door.position = StartPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {
            Door.position = Vector3.MoveTowards(Door.position, EndPoint.position, Time.deltaTime);
        }
            
    }
}
