using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {
	
	public float force;

	private Rigidbody2D rb;
	private Vector3[] directions;
	private int directionPointer;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		directions = new Vector3[2];
		directions[0] = new Vector3(1, 2, 0);
		directions[1] = new Vector3(-1, 2, 0);

		directionPointer = 0;
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)){
			rb.velocity = Vector3.zero;
			rb.AddForce(directions[directionPointer] * force);

			directionPointer++;
			if(directionPointer > 1){
				directionPointer = 0;
			}
		}		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ring")){
			StartCoroutine(WaitBeforeGeneratingLevel());
		}
    }

	IEnumerator WaitBeforeGeneratingLevel(){
		yield return new WaitForSeconds(1);
		LevelGeneratorScript.instance.GenerateLevel();
	}
}
