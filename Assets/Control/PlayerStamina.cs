using UnityEngine;
using System.Collections;

namespace Control {
    public class PlayerStamina : MonoBehaviour {
        public delegate void ConsumeDelegate ();
        public delegate void PowerupDelegate ();

        public event ConsumeDelegate OnConsume;
        public event PowerupDelegate OnPowerup;

        public int max;
        public int current;

        public void Recover () {
            max = current;
        }

        public void Powerup () {
            max += 3;
            current = max;

            if (OnPowerup != null) OnPowerup();
        }

        public void Consume () {
            current--;
            if (OnConsume != null) OnConsume();
            
            if (current == 0) {
                // TODO: die
            }
        }
    }
}
