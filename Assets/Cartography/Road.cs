using UnityEngine;
using System.Collections;

namespace Cartography {
    public class Road : Discoverable {
        public delegate void RotationReadyDelegate ();
        public event RotationReadyDelegate OnRotationReady;

        public GameObject middle;
        public RoadsNodeDetector a, b;

        private int _count = 0;

        // void Update () {
        //     middle.transform.localScale = new Vector3(0, length, 0);
        //     a.transform.localPosition = new Vector3(-length/2, 0, 0);
        //     b.transform.localRotation = new Vector3(length/2, 0, 0);
        // }

        public void Awake () {
            base.Awake();

            a.OnNodeDetected += NodeDetectedHandler;
            b.OnNodeDetected += NodeDetectedHandler;
        }

        public void NodeDetectedHandler () {
            if (a.detected != null && b.detected != null && OnRotationReady != null) {
                OnRotationReady();
            }
        }

        public float GetRotation () {
            // return transform.rotation.eulerAngles.y;
            Vector3 dif = a.detected.transform.position - b.detected.transform.position;
            return Mathf.Atan2(dif.z, dif.x) * Mathf.Rad2Deg + 90;
        }

        public bool IsRotationReady () {
            return a.detected != null && b.detected != null;
        }
    }
}
