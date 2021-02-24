using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SquareManShootTetris 
{ 
    public class GameManager : MonoBehaviour
    {
        #region Dependencies

        #endregion

        #region Public Variables

        #endregion

        #region Flags
        public bool IsPaused;
        public bool IsGameOver;
        public bool IsLoading;
        #endregion

        #region Private Variables

        #endregion

        #region Events
        public UnityEvent OnStart;
        public UnityEvent OnLoad;
        public UnityEvent OnGameOver;
        public UnityEvent OnPause;
        public UnityEvent OnUnPause;
        public UnityEvent OnRestart;
        public UnityEvent OnQuit;
        #endregion

        #region BuiltIN Methods

        #endregion

        #region Main Methods

        public void StartGame() 
        {
            IsGameOver = false;
            OnStart.Invoke();
        }

        public void LoadGame() 
        {
            OnLoad.Invoke();
        }
        public void GameOver() 
        {
            IsGameOver = true;
            OnGameOver.Invoke();
        }

        public void PauseGame() 
        {
            IsPaused = true;
            OnPause.Invoke();
            Time.timeScale = 0;
            Debug.Log("Game Paused...");
        }

        public void UnPauseGame() 
        {
            OnUnPause.Invoke();
            Time.timeScale = 1;
            Debug.Log("Game Unpaused...");
            IsPaused = false;
        }

        public void RestartGame() 
        {
            IsGameOver = false;
            IsPaused = false;
            OnRestart.Invoke();
            UnPauseGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame() 
        {
            Application.Quit();
        }

        #endregion
    }
}
