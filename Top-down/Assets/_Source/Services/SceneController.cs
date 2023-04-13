using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class SceneController
    {
        
        public static void NextLevel(int nextSceneID)
        {
            Debug.Log(nextSceneID + " " + SceneManager.sceneCountInBuildSettings);
            if (nextSceneID < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneID); // ������� �������� �� ��������� �����, ����� ��������� ���
            }
            else
            {
                Debug.Log("next level ID not available");
                // ������ ���-�� ���� ��� ��������� �������, ������ � ���� ��� ��������� ��� ����� � �.�.
            }

        }

        public static void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
