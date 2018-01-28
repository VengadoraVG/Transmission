using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Test : MonoBehaviour {
    void Update () {
        for (int i=0; i<transform.childCount; i++) {
            transform.GetChild(i).transform.position = transform.position + transform.forward * i;
        }
    }
}
