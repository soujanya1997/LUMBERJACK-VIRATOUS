using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMangerScript : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform playerTransform ;
	private float spawnZ = 11.43f;
	private int tilesOnScreen = 200 ;
	private float TileLength = 11.43f ;
	private float safeZone = 2200f ;
	private List<GameObject> ActiveTiles = new List<GameObject>();
	private int lastPrefabIndex = 0 ;
	DestroyObjects dest_obj_scrpt ;
	public GameObject player ;
	// Use this for initialization
	void Start () {
		
		dest_obj_scrpt = player.GetComponent<DestroyObjects> ();

		spawnZ += 2 * TileLength;

		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for(int i=0; i < tilesOnScreen ; i++)
		{
			spawnTile() ;
		}
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * TileLength)) {
			spawnTile ();
			destroyTile ();
		}*/

		if (playerTransform.position.z == 2200f )
			wins ();
	}

	private void spawnTile(int prefabIndex = -1)
	{
		GameObject go;
		go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += TileLength;
		ActiveTiles.Add (go);
		//dest_obj_scrpt.score += 1;
	}

	private void destroyTile()
	{
		Destroy (ActiveTiles [0]);
		ActiveTiles.RemoveAt (0);
		dest_obj_scrpt.score += 5;
	}

	private int RandomPrefabIndex()
	{
			int randomIndex = lastPrefabIndex;

			while (randomIndex == lastPrefabIndex) {
				randomIndex = Random.Range (0, tilePrefabs.Length);
			}
			lastPrefabIndex = randomIndex;

			return randomIndex;
	}

	public void wins()
	{
		GameObject.FindGameObjectWithTag("Player").transform.Rotate (new Vector3(0,100*Time.deltaTime,0));
	}
}
