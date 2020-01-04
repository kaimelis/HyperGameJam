using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mantas
{
    public class LevelManager : MonoBehaviour
    {
        private void Awake()
        {
            FindObjectOfType<Player>()._onPlayerDeath += RestartScene;
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnDisable()
        {
            FindObjectOfType<Player>()._onPlayerDeath -= RestartScene;
        }
    }
}

