using UnityEngine;
using System.Collections;

namespace Cartography {
    public delegate void NodeExploredDelegate ();
    public delegate void NodeUnexploredDelegate ();
    public class Node : MonoBehaviour {
        public static Minimap theMinimap;

        public event NodeExploredDelegate OnNodeExplored;
        public event NodeUnexploredDelegate OnNodeUnexplored;
        public bool saved = false;
        public bool discovered = false;

        void Awake () {
            if (theMinimap == null) {
                theMinimap = GameObject.FindWithTag("GameController")
                    .GetComponent<CartographyController>().theMinimap;
            }

            theMinimap.Register(this);
        }

        void OnTriggerEnter (Collider c) {
            bool discovered = true;
            if (OnNodeExplored != null) OnNodeExplored();
        }

        public void Unexplore () {
            if (OnNodeUnexplored != null) OnNodeUnexplored();
        }
    }
}
