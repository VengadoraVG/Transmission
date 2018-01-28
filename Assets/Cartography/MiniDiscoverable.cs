using UnityEngine;
using System.Collections;

namespace Cartography {
    public abstract class MiniDiscoverable : MonoBehaviour {
        public GameObject visual;

        public Discoverable _original;
        protected Minimap _minimap;

        public void Initialize (Discoverable original, Minimap theMinimap) {
            _original = original;
            _minimap = theMinimap;

            transform.parent = theMinimap.miniParent;
            transform.localRotation = Quaternion.Euler(0,0,0);

            Vector3 relPos =
                theMinimap.real.RelativeFromAbsolute(original.transform.position);
            transform.position = theMinimap.mini.AbsoluteFromRelative(relPos);

            transform.localPosition =
                Vector3.Scale(new Vector3(1,0,1), transform.localPosition);

            if (original.discovered) {
                Discover();
            } else {
                Undiscover();
            }

            original.OnDiscover += Discover;
            original.OnUndiscover += Undiscover;

            Initialize();
        }

        public abstract void Initialize ();

        public void Discover () {
            visual.gameObject.SetActive(true);
        }

        public void Undiscover () {
            visual.gameObject.SetActive(false);
        }
    }
}
