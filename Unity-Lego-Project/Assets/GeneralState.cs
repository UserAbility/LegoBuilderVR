using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralState : MonoBehaviour {
    private static GeneralState _instance;

    public static GeneralState Instance {
        get {
            if (_instance == null) {
                GameObject go = new GameObject("GeneralState");
                go.AddComponent<GeneralState>();
            }

            return _instance;
        }
    }

    public int myNum = 1234;

    private void Awake() {
        _instance = this;
    }

    public string legoColor = "blue";
    public string legoShape = "brick-1x1x1";

    string[] legoShapes = {
        "brick-1x1x1",
        "brick-1x1x2",
        "brick-1x1x4",
        "brick-1x2x2",
        "brick-1x2x4"
        };

    public void setLegoColor(int newNum) {
        myNum = newNum;
    }

    public void setLegoShape(string newLegoShape) {
        legoShape = newLegoShape;
    }

    public void incrementLegoShape() {
        int currentLegoIndex = 0;
        for (int i = 0; i < legoShapes.Length; i++) {
            if (legoShape == legoShapes[i]) {
                currentLegoIndex = i;
            }
        }
        Debug.Log(currentLegoIndex);
        Debug.Log("currentLego Index " + currentLegoIndex);
        Debug.Log("legoShapes.Length " + legoShapes.Length);
        if (currentLegoIndex < legoShapes.Length - 1) {
            legoShape = legoShapes[currentLegoIndex + 1];
        }

        else if (currentLegoIndex < legoShapes.Length) {
            Debug.Log("in other....");
            legoShape = legoShapes[0];
        }
        Debug.Log(legoShape);
    }

    public void decrementLegoShape() {
        int currentLegoIndex = 0;
        for (int i = 0; i < legoShapes.Length; i++) {
            if (legoShape == legoShapes[i]) {
                currentLegoIndex = i;
            }
        }

        if (currentLegoIndex > 0) {
            legoShape = legoShapes[currentLegoIndex - 1];
        }

        if (currentLegoIndex == 0) {
            legoShape = legoShapes[legoShapes.Length - 1];
        }

        Debug.Log(legoShape);
    }
}
