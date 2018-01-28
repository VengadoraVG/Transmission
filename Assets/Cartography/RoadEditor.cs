using UnityEngine;
using System.Collections;

namespace Cartography {
    [ExecuteInEditMode]
    public class RoadEditor : MonoBehaviour {
        public GameObject middle;
        public GameObject a, b;
        public float length = 19;

        public float Steps {
            get { return 360/8.0f; }
        }

        void Update () {
            Vector3 r = transform.rotation.eulerAngles;
            transform.rotation =
                Quaternion.Euler(0, Mathf.Round(r.y / Steps) * Steps, 0);
            transform.position = new Vector3(0, -0.355499f, 0) +
                Vector3.Scale(transform.position, new Vector3(1, 0, 1));
            
            a.transform.localPosition = new Vector3(0, 0, length/2.0f);
            b.transform.localPosition = new Vector3(0, 0, -length/2.0f);
            middle.transform.localScale = new Vector3(0, 0, length) +
                Vector3.Scale(middle.transform.localScale, new Vector3(1,1, 0));
        }
    }
}
