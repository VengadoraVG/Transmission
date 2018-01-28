using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Control  {
    public class CharacterControl : MonoBehaviour {
        public GameObject _copy;

        public GameObject pov;
        public bool controledByPlayer = true;
        public Animator mecanim;

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

            mecanim.SetBool("walking", _agent.velocity.magnitude > 0.1f);
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

        public void Die () {
            _agent.ResetPath();
            _agent.enabled = false;
            controledByPlayer = false;
        }

        public void SpawnAt (Vector3 position) {
            // transform.position = spawningPoint.transform.position;
            transform.position = position;
            _agent.enabled = true;

            // _agent.ResetPath();
            // _agent.Move(position);
        }
    }
}
