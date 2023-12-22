using UnityEngine;
using UnityEngine.SceneManagement;

public static class StaticSceneChanger
{
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Additional methods can be added as needed
}
