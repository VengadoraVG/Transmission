using UnityEngine;
using System.Collections;

namespace Cartography {
    public class BoundingBox : MonoBehaviour {
        public GameObject topLeft;
        public GameObject bottomRight;

        public Vector3 RelativeFromAbsolute (Vector3 p) {
            p -= bottomRight.transform.position;
            Vector3 size = bottomRight.transform.position - topLeft.transform.position;
            return new Vector3(p.x / size.x, 0, p.z / size.z);
        }

        public Vector3 AbsoluteFromRelative (Vector3 p) {
            Vector3 size = bottomRight.transform.position - topLeft.transform.position;
            return bottomRight.transform.position + Vector3.Scale(size, p);
        }
   }
}
