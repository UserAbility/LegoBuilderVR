using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class RightInputController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    private GeneralState state;

    // Use this for initialization
    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        state = GeneralState.Instance;
    }

    // Update is called once per frame

    // grip is SteamVR_Controller.ButtonMask.Grip
    // getting touch axis is device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0)

    void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log("Right is working");
            

        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            Debug.Log(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);
            float x = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
            float y = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;

            if (x > 0) {
                state.incrementLegoShape();
            }

            if (x <= 0) {
                state.decrementLegoShape();
            }
        }
    }
}
