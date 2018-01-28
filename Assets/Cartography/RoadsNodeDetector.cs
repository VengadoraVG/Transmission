using UnityEngine;
using System.Collections;

namespace Cartography {
    public class RoadsNodeDetector : MonoBehaviour {
        public delegate void NodeDetectedDelegate ();
        public event NodeDetectedDelegate OnNodeDetected;
        public Node detected;

        void OnTriggerEnter (Collider c) {
            detected = c.GetComponent<Node>();
            if (OnNodeDetected != null) OnNodeDetected();
        }
    }
}
