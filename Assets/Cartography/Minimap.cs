using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cartography {
    public class Minimap : MonoBehaviour {
        public BoundingBox real;
        public BoundingBox mini;

        public GameObject explorer;
        public GameObject miniExplorer;

        public Transform miniParent;

        public Dictionary<Discoverable, MiniDiscoverable> discoverables =
            new Dictionary<Discoverable, MiniDiscoverable>();

        void Update () {
            Vector3 relPos =
                real.RelativeFromAbsolute(explorer.transform.position);
            miniExplorer.transform.position =
                mini.AbsoluteFromRelative(relPos);
            miniExplorer.transform.localPosition =
                Vector3.Scale(miniExplorer.transform.localPosition, new Vector3(1, 0, 1)) +
                new Vector3(0, -0.6f, 0);
        }

        public void Register (Discoverable d) {
            discoverables[d] = Instantiate(d.miniPrototype.gameObject)
                .GetComponent<MiniDiscoverable>();
            discoverables[d].Initialize(d, this);
        }
    }
}
