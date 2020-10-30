# VR-XR-Interaction-Starter
starters project XR Interaction Toolkit
> go to master branch

# setup VR World

1. XR plugin manager: allow to select which framework we are using
2. XR interaction toolkit (= interaction system)
3.Build settings (switch to android to build for oculus quest)
4.player settings: min. API level +23
5.XR Plugin manager: select oculus 
6. Build world

## grab & throw objects
1.bal gameobject: add xr grab interactable component
(throw velocity scale: how far to throw)

## teleport
1. add locomotion system
2. add teleportation provider
3. add snap turn provider

4. create cube and add teleportation achor component

## controller usage

´´´cs
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

public class controllertest : MonoBehaviour
{

    [SerializeField]
    private XRNode controllerNode = XRNode.LeftHand;

    private InputDevice controller;

    private List<InputDevice> devices = new List<InputDevice>();

    private bool buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        GetDevice();
    }


    private void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(controllerNode, devices);
        controller = devices.FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            GetDevice();
        }

        /*
         * JOYSTICK MOVEMENT
         */
        Vector2 primary2dValue;
        InputFeatureUsage<Vector2> primary2DVector = CommonUsages.primary2DAxis;
        if (controller.TryGetFeatureValue(primary2DVector, out primary2dValue) && primary2dValue != Vector2.zero)
        {
            Debug.Log("primary2DAxisClick is pressed " + primary2dValue);
        }

        bool buttonValue;
        /*
         * CLICK X
         */
        if (controller.TryGetFeatureValue(CommonUsages.primaryButton, out buttonValue) && buttonValue)
        {
            if (!buttonPressed)
            {
                Debug.Log("primaryButton is pressed " + buttonValue);
            }
        }


            }
}
´´´
