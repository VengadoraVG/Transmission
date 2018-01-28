using UnityEngine;
using System.Collections;

namespace Control {
    public class Carry : MonoBehaviour {
        public Vector3 carryingScale = new Vector3(0.3f, 0.3f, 0.3f);
        public bool isDroppedAtVillage = true;
        public GameObject carryPlace;
        public GameObject dropPlace;
        public bool alreadyDropped = false;

        public bool isTorch;
        public bool isHammer;

        private Vector3 _originalScale;

        void Start () {
            _originalScale = transform.localScale;
        }

        void OnTriggerEnter (Collider c) {
            if (!alreadyDropped) {
                if (c.CompareTag("Explorer")) {
                    if (isTorch)
                        c.GetComponent<Cartography.Explorer>().hasFire = true;
                    else if (isHammer)
                        c.GetComponent<Cartography.Explorer>().hasHammer = true;

                    transform.parent = carryPlace.transform;
                    transform.localScale = carryingScale;
                    transform.localPosition = new Vector3(0,0,0);
                    c.GetComponent<Cartography.Explorer>().OnDie += Drop;
                } else if (c.CompareTag("Village") && isDroppedAtVillage) {
                    Drop();
                    transform.position = dropPlace.transform.position;
                    alreadyDropped = true;
                    GameObject.FindWithTag("Explorer").transform.parent.
                        GetComponent<PlayerStamina>().Powerup();
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
