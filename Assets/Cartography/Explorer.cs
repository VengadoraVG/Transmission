using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cartography {
    public class Explorer : MonoBehaviour {
        public List<Node> discovered;

        private Minimap _minimap;

        void Awake () {
            _minimap = GameObject.FindWithTag("GameController").
                GetComponent<CartographyController>().theMinimap;
        }

        void OnTriggerEnter (Collider c) {
            if (c.gameObject.CompareTag("Node")) {
                Node n = c.gameObject.GetComponent<Node>();
                if (!n.saved) {
                    discovered.Add(n);
                }
            } else if (c.gameObject.CompareTag("Village")) {
                foreach (Node n in discovered) {
                    n.saved = true;
                }
                discovered = new List<Node>();
            } else {
                foreach (Node n in discovered) {
                    n.Unexplore();
                }
                discovered = new List<Node>();
            }
        }
    }
}
