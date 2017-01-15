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
    public string legoShape = "1x1";

    public void setLegoColor(int newNum) {
        myNum = newNum;
    }

    public void setLegoShape(string newLegoShape) {
        legoShape = newLegoShape;
    }
}
