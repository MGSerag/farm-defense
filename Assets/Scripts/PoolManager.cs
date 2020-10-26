using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{

    // Bullets
    [Header("Bullets Section")]
    [SerializeField]
    private GameObject[] _bullets;
    public int bulletsCount;
    [SerializeField]
    private List<GameObject> _bulletPool;

    // Enemies
    [Header("Enemies Section")]
    [SerializeField]
    private GameObject[] _enemies;
    public int enemyCount;
    [SerializeField]
    private List<GameObject> _enemyPool;


	public override void Init() 
	{
        _bulletPool = Generatebullets(bulletsCount);
        _enemyPool = GenerateEnemies(enemyCount);
    }

	#region Bullets Pooling
	List<GameObject> Generatebullets(int amountOfbullets)
    {
        for(int i = 0; i < amountOfbullets; i++)
		{
            GameObject bullet = Instantiate(_bullets[0]);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }


        return _bulletPool;
    }

    public GameObject Requestbullet(PlayerController requester)
	{
        foreach(var obj in _bulletPool)
		{
            if (obj.activeInHierarchy == false)
			{
                obj.transform.position = requester.firePoint.transform.position;
                obj.transform.rotation = requester.firePoint.transform.rotation;

                obj.SetActive(true);
                return obj;
			}
		}

        // Expand pool

        GameObject bullet = Instantiate(_bullets[0]);
        bullet.transform.parent = this.transform;
        bullet.SetActive(false);
        _bulletPool.Add(bullet);

        return null;
	}
    #endregion

    #region Enemies Pooling
    List<GameObject> GenerateEnemies(int amountOfenemies)
    {
        for (int i = 0; i < amountOfenemies; i++)
        {
            GameObject enemy = Instantiate(_enemies[0]);
            enemy.transform.parent = SpawnManager.Instance.transform;
            enemy.SetActive(false);
            _enemyPool.Add(enemy);
        }


        return _enemyPool;
    }

    public GameObject RequestEnemy()
    {
        foreach (var obj in _enemyPool)
        {
            if (obj.activeInHierarchy == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Expand pool

        GameObject enemy = Instantiate(_enemies[0]);
        enemy.transform.parent = SpawnManager.Instance.transform;
        enemy.SetActive(false);
        _enemyPool.Add(enemy);

        return null;
    }
    #endregion
}
