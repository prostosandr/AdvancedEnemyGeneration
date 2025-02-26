using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private TargetsRepository _targetRepository;
    [SerializeField] private SpawnPoitsRepository _spawnPoitsRepository;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private float _spawnTime;

    private Transform[] _targets;
    private Transform[] _spawnPoints;

    private void Awake()
    {
        _targets = _targetRepository.GetTargets();
        _spawnPoints = _spawnPoitsRepository.GetSpawnPoints();

        Init();
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private void Init()
    {
        int minNumber = 0;

        foreach (Transform spawnPoint in _spawnPoints)
        {

            Transform randomTarget = _targets[Random.Range(minNumber, _targets.Length)];
            randomTarget.TryGetComponent(out Painter targetPainter);

            spawnPoint.gameObject.TryGetComponent(out SpawnPoint point);
            point.SetTarget(randomTarget, targetPainter.Color);
        }
    }

    private IEnumerator Spawning()
    {
        var wait = new WaitForSeconds(_spawnTime);

        while (enabled)
        {
            if (_enemyPool.NumberOfEnemies < _enemyPool.PoolCapacity)
                Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        int minNumber = 0;

        Transform spawnPoint = _spawnPoints[Random.Range(minNumber, _spawnPoints.Length)];
        spawnPoint.TryGetComponent(out SpawnPoint currentSpawnPoint);
        spawnPoint.TryGetComponent(out Painter spawnPointPainter);

        Enemy enemy = _enemyPool.GetEnemy();
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint.position;
        enemy.StartLiveCycle(currentSpawnPoint.Target, spawnPointPainter.Color);
    }
}