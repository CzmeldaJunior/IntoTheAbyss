using Unity.Cinemachine;
using UnityEngine;

public class MultiplayerCameraGroupManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineTargetGroup _targetGroup;

    [SerializeField]
    private float defaultWeight = 1.0f;
    [SerializeField]
    private float defaultRadius = 2.0f;

    private void Awake()
    {
        if (_targetGroup == null)
        {
            _targetGroup = FindAnyObjectByType<CinemachineTargetGroup>();
        }
    }

    public void RegistedTarget(Transform target)
    {
        _targetGroup.AddMember(target, defaultWeight, defaultRadius);

    }

    public void UnregisterTarget(Transform target)
    {
        _targetGroup.RemoveMember(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
