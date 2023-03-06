using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookBehavior : MonoBehaviour
{
    [SerializeField] float horizontalJointDistSpeed, verticalJointDistSpeed;
    private SpringJoint2D playerJoint;
    private Vector2 jointAnchorPoint;
    private bool walkingLeft, walkingRight;

    // Start is called before the first frame update
    void Start()
    {
        playerJoint = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //jointAnchorPoint = playerJoint.
        walkingLeft = GetComponent<PlayerMovement>().movingLeft;
        walkingRight = GetComponent<PlayerMovement>().movingRight;
        if (walkingLeft)
        {

        }
    }
}
