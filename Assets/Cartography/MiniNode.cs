using UnityEngine;
using System.Collections;

namespace Cartography {
    public class MiniNode : MonoBehaviour {
        public SpriteRenderer visual;

        public void Explore () {
            visual.gameObject.SetActive(true);
        }

        public void Unexplore () {
            visual.gameObject.SetActive(false);
        }
    }
}
