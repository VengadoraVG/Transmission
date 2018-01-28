using UnityEngine;
using System.Collections;
using Cartography;

namespace Control {
    public class PlayerStamina : MonoBehaviour {
        public delegate void StaminaChangeDelegate ();

        public event StaminaChangeDelegate OnStaminaChange;

        public int max;
        public int current;
        public Explorer explorer;

        void Awake () {
            explorer.OnVillageVisit += Recover;
        }

        public void Recover () {
            current = max;
            if (OnStaminaChange != null) OnStaminaChange();
        }

        public void Powerup () {
            max += 3;
            current = max;

            if (OnStaminaChange != null) OnStaminaChange();
        }

        public void Consume () {
            if (current == 0) {
                // TODO: die
            }

            current--;
            if (OnStaminaChange != null) OnStaminaChange();
        }
    }
}
