using UnityEngine;

public class TargetsRepository : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int targetCount = transform.childCount;
        _targets = new Transform[targetCount];

        for (int i = 0; i < targetCount; i++)
            _targets[i] = transform.GetChild(i);
    }
#endif

    public Transform[] GetTargets()
    {
        return _targets;
    }
}