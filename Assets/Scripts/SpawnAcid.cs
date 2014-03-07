using System.Collections;
using UnityEngine;

public class SpawnAcid : MonoBehaviour {
	
	public Vector3 ObjectSpawnPosition;
	public GameObject obj;
	public Vector3 acidOffSet;
	private float counter = 0;

	void Start()
	{
		acidOffSet = this.gameObject.transform.right * -1.5f;
	}
	
	void Update()
	{
		counter += Time.deltaTime;
		if(counter >=5)
		{
			//DestroyObject(obj);
		}
		ObjectSpawnPosition = this.gameObject.transform.position + (acidOffSet);

		if(Input.GetKeyDown(KeyCode.X)) {
			Instantiate(obj, ObjectSpawnPosition, Quaternion.identity);

		}
}

}