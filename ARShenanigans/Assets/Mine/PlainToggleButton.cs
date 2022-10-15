using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace Mine {
    public class PlainToggleButton : MonoBehaviour {
        private TMP_Text planeToggleText;
        private Button planeToggleButton; 
        private ARPlaneManager planeManager;
        private bool isEnabled = true;
        

        private void Start() {
            planeManager = FindObjectOfType<ARPlaneManager>();
            planeToggleButton = GetComponent<Button>();
            planeToggleText = planeToggleButton.GetComponentInChildren<TMP_Text>();
            
            planeToggleText.text = "Enabled";
            planeToggleButton.onClick.AddListener(TogglePlanDetection);
        }

        private void TogglePlanDetection() {
            isEnabled = planeManager.enabled;
            isEnabled = !isEnabled;
            
            planeManager.enabled = isEnabled;
            planeToggleText.text = isEnabled ? "Enabled" : "Disabled";

            foreach (var planes in planeManager.trackables) {
                planes.gameObject.SetActive(isEnabled);
            }
    
        }
    }
}