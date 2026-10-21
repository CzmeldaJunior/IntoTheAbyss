using UnityEngine;

public class TargetGroupAutoRegister : MonoBehaviour
{
    private MultiplayerCameraGroupManager _groupManager;
    void Awake()
    {
        _groupManager = FindAnyObjectByType<MultiplayerCameraGroupManager>();

        if (_groupManager != null)
        {
            _groupManager.RegistedTarget(transform);
        }
    }

    private void OnDestroy()
    {
        if (_groupManager != null)
        {
            _groupManager.UnregisterTarget(transform);
        }
    }
}
