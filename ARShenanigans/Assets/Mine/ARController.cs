using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour {

    public GameObject myObject;
    public ARRaycastManager raycastManager;

    private void Update() {
        if (Input.touchCount <= 0) return;
        
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;

        var touches = new List<ARRaycastHit>();
        raycastManager.Raycast(touch.position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        if (touches.Count <= 0) return;
        
        var hitPose = touches[0].pose;
        Instantiate(myObject, hitPose.position, hitPose.rotation);
    }
}
