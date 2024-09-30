using UnityEngine;

public class ScenesChangerButton : MonoBehaviour
{
    public void ChangeScene(string sceneName) 
    {
        ScenesManager.ScenesManagerInstance.StartLoading(sceneName);
    }
}
