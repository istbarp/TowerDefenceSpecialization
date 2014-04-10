using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {

	private bool isPlaced = false;
	public float damage = 10f;
	public float upgradeMultiplier = 1.5f;
	private float reloadTime = 1f;
	private float reloadTimer = 0;

	public List<GameObject> ReachableEnemies = new List<GameObject>();

	public GameObject ThisTower;

	
	void Update () {
		if (!isPlaced) 
		{
			//MoveTower();
			//return;
		}

		if (ReachableEnemies.Count != 0)
		{
			Fire();
		}

		reloadTimer += Time.deltaTime;
	}

	private void Fire()
	{
		if (reloadTime < reloadTimer)
		{
			if (ReachableEnemies[0].gameObject != null)
			{
				ReachableEnemies[0].GetComponent<Enemy>().CurrentHealth -= damage;
				reloadTimer = 0;
				if (ReachableEnemies[0].GetComponent<Enemy>().CurrentHealth <= 0)
				{
					ReachableEnemies.RemoveAt(0);
				}
			}
			else
			{
				ReachableEnemies.RemoveAt(0);
			}
		}
	}

	private void MoveTower()
	{

	}

	public void UpgradeTower()
	{
		damage = damage * upgradeMultiplier;
	}
	
	void OnTriggerEnter(Collider Other)
	{
		ReachableEnemies.Add(Other.gameObject);
	}
	
	void OnTriggerExit(Collider Other)
	{
		ReachableEnemies.Remove(Other.gameObject);
	}
}
