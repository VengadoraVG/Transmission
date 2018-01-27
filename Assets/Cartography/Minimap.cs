using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cartography {
    public class Minimap : MonoBehaviour {
        public BoundingBox real;
        public BoundingBox mini;

        public GameObject miniNodePrototype;
        public GameObject miniExplorer;
        public GameObject miniNodesParent;
        public GameObject explorer;

        public Dictionary<Node, MiniNode> nodes =
            new Dictionary<Node, MiniNode>();

        void Update () {
            Vector3 relPos =
                real.RelativeFromAbsolute(explorer.transform.position);
            miniExplorer.transform.position =
                mini.AbsoluteFromRelative(relPos);
        }

        public void Register (Node node) {
            MiniNode miniNode = Instantiate(miniNodePrototype).
                GetComponent<MiniNode>();
            nodes[node] = miniNode;
            miniNode.transform.parent = miniNodesParent.transform;

            Vector3 relativePosition =
                real.RelativeFromAbsolute(node.transform.position);
            miniNode.transform.position =
                mini.AbsoluteFromRelative(relativePosition);

            if (node.discovered) {
                miniNode.Explore();
            } else {
                miniNode.Unexplore();
            }

            node.OnNodeExplored += miniNode.Explore;
            node.OnNodeUnexplored += miniNode.Unexplore;
        }
    }
}
