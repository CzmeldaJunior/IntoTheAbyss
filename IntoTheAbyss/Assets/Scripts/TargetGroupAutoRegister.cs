using UnityEngine;

public class TargetGroupAutoRegister : MonoBehaviour
{
    private MultiplayerCameraGroupManager _groupManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
