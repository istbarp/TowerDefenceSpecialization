using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private float spawntimer = 0;
	public int WaveSize = 1;
	public GameObject EnemyThis;
	public float level = 0f;
	public float levelmultiplier = 1.05f;
	public bool spawnerActive;

	// Update is called once per frame
	void Update () {
		if (spawnerActive)
		{
			spawntimer += Time.deltaTime;
			if (spawntimer > 1)
			{
				GameObject.Instantiate(EnemyThis, this.transform.position, this.transform.rotation);
				spawntimer = 0;
				WaveSize--;
			}
		}
		if (WaveSize == 0)
		{
			spawnerActive = false;
			spawntimer = 0;
		}
	}

	void OnGUI ()
	{
		if(GUI.Button(new Rect(20,20,80,20),"NextWave"))
		{
			level++;
			EnemyThis.GetComponent<Enemy>().BaseHealth = 10 * (level * levelmultiplier);
			WaveSize = 6;
			spawnerActive = true;
		}
	}
}
