using UnityEngine;

public class ApplicationExitHandler : MonoBehaviour
{
    public void ExitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}