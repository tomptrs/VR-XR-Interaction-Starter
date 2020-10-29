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
