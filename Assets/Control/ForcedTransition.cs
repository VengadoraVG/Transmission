using UnityEngine;
using System.Collections;

namespace Control {
    public class ForcedTransition : MonoBehaviour {
        public GameObject target;

        void OnTriggerEnter (Collider c) {
            CharacterControl control =
                c.transform.parent.GetComponent<CharacterControl>();

            if (control.controledByPlayer) {
                control.ForceMovement(target.transform.position);
                control.GetComponent<PlayerStamina>().Consume();
            }
        }
    }
}
