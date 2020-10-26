using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
	public float RespawnTimer = 3f;
	private float timer = 3f;

	private void Update()
	{
		timer = timer - Time.deltaTime;

		if(timer < 0)
		{
			Spawn();
			timer = RespawnTimer;
		}
	}

	void Spawn()
	{
		GameObject enemy = PoolManager.Instance.RequestEnemy();
	}
}


