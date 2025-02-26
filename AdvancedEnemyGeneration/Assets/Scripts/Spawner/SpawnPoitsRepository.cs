using UnityEngine;

public class SpawnPoitsRepository : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;
        _spawnPoints = new Transform[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
    }
#endif

    public Transform[] GetSpawnPoints()
    {
        return _spawnPoints;
    }
}