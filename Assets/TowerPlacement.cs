using UnityEngine;
using System.Collections;

public class TowerPlacement : MonoBehaviour {

	public GameObject Tower;

	public static bool Tower1ButtonPressed;
	public static bool Tower2ButtonPressed;
	public static bool Tower3ButtonPressed;
	
	void Update() {
	
		if (Input.GetButtonDown("Fire1")) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				print (hit.collider.tag);

				if(hit.collider.tag == "Tower" || hit.collider.tag == "Path")
				{
					print("hitting something");
				}
				else if (Tower1ButtonPressed == true)
				{
					Instantiate(Tower, hit.point, Quaternion.identity);
					Tower1ButtonPressed = false;
				}
	
			}
		}		
	}
}
