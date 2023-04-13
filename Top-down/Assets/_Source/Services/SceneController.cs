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
                SceneManager.LoadScene(nextSceneID); // сделать проверку на последнюю сцену, когда следующей нет
            }
            else
            {
                Debug.Log("next level ID not available");
                // делаем что-то если это последний уровень, кидаем в меню или запускаем кат сцену и т.д.
            }

        }

        public static void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
