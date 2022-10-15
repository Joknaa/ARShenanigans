using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour {

    public GameObject myObject;
    public ARRaycastManager raycastManager;

    private List<GameObject> spawnedObjects = new List<GameObject>();
    
    private void Update() {
        if (Input.touchCount <= 0) return;
        
        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;

        var touches = new List<ARRaycastHit>();
        raycastManager.Raycast(touch.position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        if (touches.Count <= 0) return;
        
        var hitPose = touches[0].pose;
        spawnedObjects.Add(Instantiate(myObject, hitPose.position, Quaternion.identity));
    }
    
    
    public void ClearObjects() {
        foreach (var obj in spawnedObjects) {
            Destroy(obj);
        }
        spawnedObjects.Clear();
    }
    
    public void SetObjectsSize(Slider slider) {
        foreach (var obj in spawnedObjects) {
            obj.transform.localScale = Vector3.one * slider.value;
        }
        
        myObject.transform.localScale = Vector3.one * slider.value;
    }
    
    
}
