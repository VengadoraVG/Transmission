using UnityEngine;
using System.Collections;

namespace Cartography {
    public class MiniRoad : MiniDiscoverable {
        public override void Initialize () {
            transform.localPosition = new Vector3(0,0.1f,0);
            Road r = _original.GetComponent<Road>();
            if (!r.IsRotationReady()) {
                r.OnRotationReady += SetRotation;
            } else {
                SetRotation();
            }
            transform.localScale = new Vector3(1, 1, 1);
            // transform.Translate(0, 0.1f, 0);
        }

        public void SetRotation () {
            LineRenderer lr = visual.GetComponent<LineRenderer>();
            Road r = _original.GetComponent<Road>();
            Node a = r.a.detected, b = r.b.detected;
            lr.SetPosition(0, Vector3.Scale(new Vector3(1, 0, 1), _minimap.discoverables[a].transform.localPosition));
            lr.SetPosition(1, Vector3.Scale(new Vector3(1, 0, 1), _minimap.discoverables[b].transform.localPosition));
        }
    }
}
