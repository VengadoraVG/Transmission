using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Control  {
    public class CharacterControl : MonoBehaviour {
        public GameObject pov;
        public bool controledByPlayer = true;

        private NavMeshAgent _agent;
        
        void Start () {
            _agent = GetComponent<NavMeshAgent>();
        }

        void Update () {
            if (controledByPlayer) {
                Vector3 direction = Input.GetAxis("Horizontal") * pov.transform.right +
                    Input.GetAxis("Vertical") * pov.transform.forward;
                if (direction.magnitude > 0) {
                    _agent.SetDestination(transform.position + direction);
                }
            }
        }

        public void ForceMovement (Vector3 position) {
            _agent.SetDestination(position);
            controledByPlayer = false;
            StartCoroutine(EventuallyRecoverControl());
        }

        IEnumerator EventuallyRecoverControl () {
            yield return new WaitForSeconds(1.5f);
            controledByPlayer = true;
            _agent.ResetPath();
        }
    }
}
