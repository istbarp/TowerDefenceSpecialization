using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Enemy : MonoBehaviour
{
	public List<Transform> WayPoints = new List<Transform>();
	public float Offset = 0.001f;
	private int CurrentWaypoint;

	public float BaseHealth = 10;
	public float CurrentHealth;

	public int Value = 1;
	public int Damage = 1;
	
	//Rotation Stuff
	private Quaternion toRot;
	private Quaternion frRot;
	private float spRot = 0;
	
	GUITexture HealthBar;
	
	void Start()
	{
		CurrentHealth = BaseHealth;
		CurrentWaypoint = 0;
		if (Offset < 0.00001)
		{
			Offset = 0.00001f;
		}
		if (Offset > 1)
		{
			Offset = 1;
		}
		
		WayPoints = (GameObject.Find("WaypointsLevel1").transform.GetComponentsInChildren<Transform>()).ToList<Transform>();
		WayPoints.RemoveAt(0);
		this.transform.LookAt(WayPoints[0]);
		toRot = this.transform.rotation;
	}
	
	void Update()
	{
		Move();
		if (CurrentHealth <= 0)
		{
			Destroy(this.gameObject);
			//StaticValues.Money += Value;
		}
	}
	
	/// <summary>
	/// Moves the enemy towards a waypoint 
	/// </summary>
	void Move()
	{
		if (Quaternion.Angle(this.transform.rotation, toRot) > Offset)
		{
			this.transform.rotation = Quaternion.Slerp(frRot, toRot, Time.deltaTime + spRot);
			spRot += Time.deltaTime;
		}
		else
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, WayPoints[CurrentWaypoint].position, 0.5f * Time.deltaTime);
			spRot = 0;
		}
		
		if (Vector3.Distance(this.transform.position, WayPoints[CurrentWaypoint].position) < Offset)
		{
			if (CurrentWaypoint == WayPoints.Count() - 1)
			{
				Destroy(this.gameObject);
				//GameObject.Find("Base").GetComponent<Base>().Life--;
			}
			else
			{
				CurrentWaypoint++;
				frRot = this.transform.rotation;
				toRot = Quaternion.LookRotation(WayPoints[CurrentWaypoint].position - transform.position);
			}
		}
	}
	
	public void TakeDamage(float damage)
	{
		//this.TakenDamage += damage;
	}
}

