using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
	//public
	public GameController gController;

	//private
	private bool alreadyTouched = false;
	private void OnCollisionEnter(Collision collision)
	{
		if (alreadyTouched == false)
		{
			if (collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Floor"))
			{	
				Debug.Log($"Toco {gameObject}");
				alreadyTouched = true;
				RemovePoint();
			}
		}
	}

	private void RemovePoint()
	{
		gController.VictoryRemovePoint();
		Destroy(gameObject, 0.5f);
	}
}