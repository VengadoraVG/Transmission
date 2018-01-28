using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Control  {
    public class CharacterControl : MonoBehaviour {
        public GameObject pov;

        private NavMeshAgent _agent;
        
        void Start () {
            _agent = GetComponent<NavMeshAgent>();
        }

        void Update () {
            Vector3 direction = Input.GetAxis("Horizontal") * pov.transform.right +
                Input.GetAxis("Vertical") * pov.transform.forward;
            if (direction.magnitude > 0) {
                _agent.SetDestination(transform.position + direction);
            }
        }
    }
}
