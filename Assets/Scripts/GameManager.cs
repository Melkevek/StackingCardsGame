using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MelkevekGames
{
    public class GameManager : MonoBehaviour
    {
        public enum GameState
        {
            Play,
            Menu,
            GeneralPaused,
            Gameover,
            None
            
        }
        public GameState gameState;
        private bool gamePause;

        [SerializeField]
        private GameObject buttonPause;
        [SerializeField]
        private GameObject menuPause;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamePause)
                {
                    gameState= GameState.Play;
                }
                else
                {
                    gameState= GameState.GeneralPaused;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PruebaTablero"></param>
        public void Play(string PruebaTablero)
        {
            SceneManager.LoadScene(PruebaTablero);
           
        }
        /// <summary>
        /// 
        /// </summary>
        public void GeneralPause()
        {
          
            Time.timeScale = 0f;
            buttonPause.SetActive(false);
            menuPause.SetActive(true);
            gamePause = true;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Resume()
        {
            Time.timeScale = 1f;
            buttonPause.SetActive(true);
            menuPause.SetActive(false);
            gamePause = false;
        }


        //public void Replay()
        //{
        //    // Reinicia la partida
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //    gameState = GameState.Menu;
        //}


        public void Options()
        {
            // Muestra el panel de opciones
            // Aquí puedes poner el código para mostrar el panel de opciones
            Debug.Log("Mostrando panel de opciones");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Exit()
        {
            // Cierra el juego
            Application.Quit();
            Debug.Log("Cerrando el Juego");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newState"></param>
        private void SetGameStates(GameState newState)
        {
            gameState = newState;
            Debug.Log($"Estado actual: {gameState}");


        }
        private void PlayStates()
        {

            // realizar acciones específicas para cada estado
            switch (gameState)
            {
                case GameState.Play:
                    Resume();
                    
                    break;
                case GameState.Menu:
                    
                    break;
                case GameState.GeneralPaused:
                    GeneralPause();
                    
                    // menu de pausa
                    break;
                case GameState.Gameover:
                    
                    break;
                case GameState.None:
                    break;
            }

        }
    }
}
