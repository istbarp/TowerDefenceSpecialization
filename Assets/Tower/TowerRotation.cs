using UnityEngine;
using System.Collections;

public class TowerRotation : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
		TowerAim();
	}

	void TowerAim()
	{
		if (transform.parent.GetComponent<Tower>().ReachableEnemies.Count != 0)
		{
			try
			{
				transform.LookAt(transform.parent.GetComponent<Tower>().ReachableEnemies[0].transform.position);
				transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y - 280, 0);
			}
			catch(MissingReferenceException e)
			{

			}
		}
	}


}
