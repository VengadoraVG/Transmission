using UnityEngine;
using System.Collections;

namespace Control {
    public class Follow : MonoBehaviour {
        public GameObject target;
        
        void Update () {
            transform.position = target.transform.position;
        }
    }
}
