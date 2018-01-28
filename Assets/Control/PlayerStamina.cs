using UnityEngine;
using System.Collections;

namespace Control {
    public class PlayerStamina : MonoBehaviour {
        public int maxStamina;
        public int currentStamina;

        public void Recover () {
            maxStamina = currentStamina;
        }

        public void Powerup () {
            maxStamina += 3;
        }
    }
}
