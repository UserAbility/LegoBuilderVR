using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandBrick : MonoBehaviour {

    private GeneralState state;
    private GameObject rightController;
    private string currentBrickString;
    private GameObject currentBrick;

    // Use this for initialization
    void Awake() {
        state = GeneralState.Instance;
        rightController = GameObject.FindGameObjectWithTag("RightController");
        
        currentBrick = Instantiate(Resources.Load("Prefabs/brick-1x1x1", typeof(GameObject))) as GameObject;
        currentBrick.transform.localScale = new Vector3(0.095f, 0.095f, 0.095f);
        currentBrick.transform.localPosition = new Vector3(0, 0, 0.1f);
        currentBrick.AddComponent<Rigidbody>();
        currentBrick.AddComponent<FixedJoint>();
        currentBrick.tag = "CurrentBrick";

        Rigidbody rb = currentBrick.GetComponent<Rigidbody>();
        Rigidbody controllerRigidbody = rightController.GetComponent<Rigidbody>();
        FixedJoint fj = currentBrick.GetComponent<FixedJoint>();
        fj.connectedBody = controllerRigidbody;
        rb.useGravity = true;
        rb.isKinematic = false;
        
        Debug.Log(rb.useGravity);

        currentBrickString = "brick-1x1x1";
        
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (currentBrickString != state.legoShape && state.changeShape) {
            Debug.Log("Change!" + currentBrickString + " " + state.legoShape);
            string path = "Prefabs/" + state.legoShape;
            GameObject newBrick = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
            newBrick.transform.localScale = new Vector3(0.095f, 0.095f, 0.095f);
            newBrick.transform.localPosition = new Vector3(
                rightController.transform.localPosition.x,
                rightController.transform.localPosition.y + 0.1f,
                rightController.transform.localPosition.z
            ) ;
            newBrick.AddComponent<Rigidbody>();
            newBrick.AddComponent<FixedJoint>();


            Rigidbody rb = newBrick.GetComponent<Rigidbody>();
            Rigidbody controllerRigidbody = rightController.GetComponent<Rigidbody>();
            FixedJoint fj = newBrick.GetComponent<FixedJoint>();

            fj.connectedBody = controllerRigidbody;
            rb.useGravity = true;
            rb.isKinematic = false;
            currentBrick.gameObject.tag = "OldCurrentBrick";
            
            currentBrick = newBrick;
            currentBrick.gameObject.tag = "CurrentBrick";
            currentBrickString = state.legoShape;

            state.droppedBrick = false;
            state.changeShape = false;
        }
	}

    public GameObject GetCurrentBrick () {
        return currentBrick;
    }
}
