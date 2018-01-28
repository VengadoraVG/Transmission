using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Test : MonoBehaviour {
    void Update () {
        for (int i=0; i<transform.childCount; i++) {
            //transform.GetChild(i).transform.position = transform.position + transform.forward * i;
			transform.GetChild(i).transform.position = transform.position + new Vector3(Random.Range(0.5f, 5) ,2f, Random.Range(0.5f, 5));
        }
        // alsdkfjleifjslidi
    }
}
