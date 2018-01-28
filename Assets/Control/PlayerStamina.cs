using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cartography;

namespace Control {
    public class PlayerStamina : MonoBehaviour {
        public delegate void StaminaChangeDelegate ();

        public event StaminaChangeDelegate OnStaminaChange;

        public GameObject spawningPoint;
        public GameObject corpsePrototype;
        public int max;
        public int current;
        public Explorer explorer;
        public Animator mecanim;

        public List<GameObject> aldeanos;
        public int x;

        void Awake () {
            x = aldeanos.Count - 1;
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
                mecanim.SetTrigger("die");
                GetComponent<CharacterControl>().Die();
                explorer.Die();
                StartCoroutine(EventuallyRespawn());
            }

            current--;
            if (OnStaminaChange != null) OnStaminaChange();
        }

        IEnumerator EventuallyRespawn () {
            CharacterControl c = GetComponent<CharacterControl>();
            c.Die();

            yield return new WaitForSeconds (1);
            mecanim.SetTrigger("respawn");
            Instantiate(corpsePrototype).transform.position = transform.position;

            c.SpawnAt(spawningPoint.transform.position);
            c.controledByPlayer = true;
            Destroy(aldeanos[x]);
            x--;
        }
    }
}
