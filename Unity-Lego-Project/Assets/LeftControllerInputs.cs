using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class LeftControllerInputs : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    private GameObject generalState;

    private void OnEnable() {
       // _controller = GetComponent<SteamVR_TrackedController>();

        // _controller.OnTriggerClicked = this.handleTriggerClicked;
    }

    private void OnDisable() {

    }

    // Use this for initialization
    void Awake () {
        Debug.Log("YOYOYOYOYOYOYOY");
        trackedObj = GetComponent<SteamVR_TrackedObject>();

       
    }

    // Update is called once per frame
    void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
            // Debug.Log(GeneralState.Instance.myNum);
            int oldNum = GeneralState.Instance.myNum;
            GeneralState.Instance.setMyNum(++oldNum);
            Debug.Log(GeneralState.Instance.myNum);
            this.fartSomething();
        }

        //if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
        //    Debug.Log("Pressed up!");
        //}

        //if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
        //    Debug.Log("touch down son.");
        //}

        //if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            
        //    if (device.GetHairTrigger()) {
        //        Debug.Log("touch man!");
        //    }
        //}
    }

    private void fartSomething() {
        GameObject thing = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        thing.AddComponent<Rigidbody>();
        thing.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
