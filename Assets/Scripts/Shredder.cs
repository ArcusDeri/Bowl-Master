using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit(Collider collider){
		var objectLeft = collider.gameObject;
		if(objectLeft.GetComponent<Pin>()){
			Destroy(objectLeft);
		}
	}
}
