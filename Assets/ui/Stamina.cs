using UnityEngine;
using System.Collections;

namespace MyUI {
    public class Stamina : MonoBehaviour {
        public Animator animator;

        public void SetFull () {
            animator.SetTrigger("full");
        }

        public void SetEmpty () {
            animator.SetTrigger("empty");
        }
    }
}
