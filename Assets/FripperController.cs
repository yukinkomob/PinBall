using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;

    private float defaultAngle = 20;
    private float flickAngle = -20;
    private bool isLeftFlipperDown = false;

    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && tag == "LeftFlipperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)) && tag == "LeftFlipperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && tag == "RightFlipperTag")
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)) && tag == "RightFlipperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && (tag == "LeftFlipperTag" || tag == "RightFlipperTag"))
        {
            SetAngle(this.flickAngle);
        }
        if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && (tag == "LeftFlipperTag" || tag == "RightFlipperTag"))
        {
            SetAngle(this.defaultAngle);
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (isLeftSideOfWindow(touch.position.x) && tag == "LeftFlipperTag")
                {
                    SetAngle(this.flickAngle);
                }
                if (isRightSideOfWindow(touch.position.x) && tag == "RightFlipperTag")
                {
                    SetAngle(this.flickAngle);
                }

            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (tag == "LeftFlipperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                if (tag == "RightFlipperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    bool isLeftSideOfWindow(float x)
    {
        return x < (Screen.width / 2);
    }

    bool isRightSideOfWindow(float x)
    {
        return x >= (Screen.width / 2);
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
