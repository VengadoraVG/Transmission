using UnityEngine;
using System.Collections;

namespace Cartography {
    public class RecoveryPoint : MonoBehaviour {
        void OnTriggerEnter (Collider c) {
            c.transform.parent.GetComponent<Control.PlayerStamina>().Recover();
        }
    }
}
