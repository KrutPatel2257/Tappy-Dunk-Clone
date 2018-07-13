using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour {

	public static LevelGeneratorScript instance;

	public GameObject ring;
	public GameObject spikePrefab;
	public GameObject rodPrefab;
	public Vector3 spikePosition;
	public Vector3 ringPosition;
	public Vector3 rodPosition;

	private List<GameObject> levelObjects = new List<GameObject>();

	void Awake(){
		instance = this;
	}

	void Start(){
		GenerateLevel();
	}

	public void GenerateLevel(){
		foreach (GameObject spike in levelObjects)
		{
			Destroy(spike);			
		}
		levelObjects.Clear();
		CreateSpike();
		SetRing();
	}

	public void CreateSpike(){
		GameObject spike = Instantiate(spikePrefab);
		levelObjects.Add(spike);
		switch(Random.Range(0,4)){
			case 0: // top 
				spike.transform.position = new Vector3(
											Random.Range(-spikePosition.x, spikePosition.x),
											spikePosition.y, 
											0);
				spike.transform.rotation = Quaternion.Euler(0, 0, -90);
				break;
			case 1: // bot 
				spike.transform.position = new Vector3(
											Random.Range(-spikePosition.x, spikePosition.x),
											-spikePosition.y, 
											0);
				spike.transform.rotation = Quaternion.Euler(0, 0, 90);
				break;
			case 2: // left
				spike.transform.position = new Vector3(
											-spikePosition.x,
											Random.Range(-spikePosition.y, spikePosition.y),
											0);
				spike.transform.rotation = Quaternion.Euler(0, 0, 0);
				break;
			case 3: // right
				spike.transform.position = new Vector3(
											spikePosition.x,
											Random.Range(-spikePosition.y, spikePosition.y),
											0);
				spike.transform.rotation = Quaternion.Euler(0, 0, 180);
				break;
		}

		if(Random.Range(0,5) <= 2){
			GameObject rod = Instantiate(rodPrefab, new Vector3(rodPosition.x, Random.Range(-rodPosition.y, rodPosition.y), 0), rodPrefab.transform.rotation);
			levelObjects.Add(rod);
		}
	}

	public void SetRing(){
		ring.SetActive(false);
		ring.transform.position = new Vector3(
			Random.Range(-ringPosition.x, ringPosition.x),
			Random.Range(-ringPosition.y, ringPosition.y),
			0);
		ring.transform.rotation = Quaternion.identity;
		ring.SetActive(true);
	}
}
