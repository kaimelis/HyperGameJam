using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mantas
{
    public class LevelManager : MonoBehaviour
    {
        private Player player;

        private void Awake()
        {
            player = FindObjectOfType<Player>();

            if(player != null)
                player._onPlayerDeath += RestartScene;
        }

        private void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnDisable()
        {
            if (player != null)
                player._onPlayerDeath -= RestartScene;
        }
    }
}

