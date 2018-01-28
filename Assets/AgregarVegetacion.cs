using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgregarVegetacion : MonoBehaviour {
	public GameObject _vegetacion;
	// Use this for initialization
	void Start() {
		GameObject _hVegetacion = Instantiate (_vegetacion, transform.position, transform.rotation);
		_hVegetacion.transform.SetParent (transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
