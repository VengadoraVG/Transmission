using UnityEngine;
using System.Collections;
using Cartography;

namespace Control {
    public class DestroyWithTool : MonoBehaviour {
        public GameObject target;
        public bool withHammer;
        public bool withFire;

        void OnTriggerEnter (Collider c) {
            Explorer e = c.GetComponent<Explorer>();
            if ((e.hasFire && withFire) || (e.hasHammer && withHammer)) {
                target.SetActive(false);
            }
        }
    }
}
