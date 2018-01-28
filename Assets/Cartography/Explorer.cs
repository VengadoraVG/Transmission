using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cartography {
    public class Explorer : MonoBehaviour {
        public List<Discoverable> discovered;
        public GameObject foodPlace;

        private Minimap _minimap;

        void Awake () {
            _minimap = GameObject.FindWithTag("GameController").
                GetComponent<CartographyController>().theMinimap;
        }

        void OnTriggerEnter (Collider c) {
            if (c.gameObject.CompareTag("Discoverable")) {
                Discoverable n = c.gameObject.GetComponent<Discoverable>();
                if (!n.saved) {
                    discovered.Add(n);
                }
            } else if (c.gameObject.CompareTag("Village")) {
                foreach (Discoverable n in discovered) {
                    n.saved = true;
                }
                discovered = new List<Discoverable>();
            } else if (c.gameObject.CompareTag("Danger")) {
                foreach (Node n in discovered) {
                    n.Unexplore();
                }
                discovered = new List<Discoverable>();
            }
        }
    }
}
