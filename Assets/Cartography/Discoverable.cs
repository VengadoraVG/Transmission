using UnityEngine;
using System.Collections;

namespace Cartography {
    public delegate void DiscoveredDelegate ();
    public delegate void UndiscoveredDelegate ();

    public class Discoverable : MonoBehaviour {
        public static Minimap theMinimap;

        public GameObject miniPrototype;
        public bool saved = false;
        public bool discovered = false;
        public bool isStatic = true;

        public event DiscoveredDelegate OnDiscover;
        public event UndiscoveredDelegate OnUndiscover;

        public void Awake () {
            if (theMinimap == null) {
                theMinimap = GameObject.FindWithTag("GameController")
                    .GetComponent<CartographyController>().theMinimap;
            }

            theMinimap.Register(this);
        }

        void OnTriggerEnter (Collider c) {
            if (c.gameObject.CompareTag("Explorer")) {
                discovered = true;
                if (OnDiscover != null) OnDiscover();
            }
        }

        public void Unexplore () {
            if (OnUndiscover != null) OnUndiscover();
        }
    }
}
