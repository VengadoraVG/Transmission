using UnityEngine;
using System.Collections;

namespace Control {
    public class Carry : MonoBehaviour {
        public Vector3 carryingScale = new Vector3(0.3f, 0.3f, 0.3f);
        public bool isDroppedAtVillage = true;
        public GameObject place;
        public bool alreadyDropped = false;

        private Vector3 _originalScale;

        void Start () {
            _originalScale = transform.localScale;
        }

        void OnTriggerEnter (Collider c) {
            if (!alreadyDropped) {
                if (c.CompareTag("Explorer")) {
                    transform.parent =
                        c.GetComponent<Cartography.Explorer>().foodPlace.transform;
                    transform.localScale = carryingScale;
                    transform.localPosition = new Vector3(0,0,0);
                } else if (c.CompareTag("Village")) {
                    Drop();
                    transform.position = place.transform.position;
                    alreadyDropped = true;
                }
            }
        }

        public void Drop () {
            transform.parent = null;
            transform.localScale = _originalScale;
        }

        public void Disappear () {
            gameObject.SetActive(false);
        }
    }
}
