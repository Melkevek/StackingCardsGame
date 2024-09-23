using MelkevekGames;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum GameState
    {
        Day,
        Night,
        Paused,
        GeneralPaused,
        None,
        Dawn

    }

    public float dayNightInterval = 45f;
    public BoardController gridController; //script de control de grid 
    public int cardsLimit;
    public GameState currentState;
    private float timer;
    [SerializeField]
    private GameObject sunIcon;
    [SerializeField]
    private GameObject moonIcon;

    private void Start()
    {
        // Iniciar en el estado de día
        SetGameState(GameState.Day);
        cardsLimit = 10;
        timer = 0f;

    }

    private void Update()
    {
        // Alternar entre día y noche cada 45 segundos
        
        
        LevelState();


        

    }
 /// <summary>
 /// 
 /// </summary>
    private void CheckCardLimit()
    {
        if (gridController.instantiatedCards.Count >= cardsLimit)
        {
            Debug.Log("You have reached the card limit, sell some cards to continue");
            
        }
        else if (gridController.instantiatedCards.Count<= cardsLimit)
        {
            SetGameState(GameState.Day);
        }
    }
   /// <summary>
   /// 
   /// </summary>
    private void ToggleDayNight()
    {
        if (timer >= dayNightInterval)
        {
             
            if (currentState == GameState.Day)
            {
                SetGameState(GameState.Night);
                sunIcon.SetActive(false);
                moonIcon.SetActive(true);
            }
            else if (currentState == GameState.Night) 
            {
                                
                SetGameState(GameState.Dawn);
                sunIcon.SetActive(true);
                moonIcon.SetActive(false);
            }
            timer = 0f;
        }
                
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newState"></param>
    private void SetGameState(GameState newState)
    {
        currentState = newState;
        Debug.Log($"Estado actual: {currentState}");

        
    }
  
    private void LevelState()
    {

        // realizar acciones específicas para cada estado
        switch (currentState)
        {
            case GameState.Day:
                timer += Time.deltaTime;// Acciones para el día
                gridController.Inputs();
                ToggleDayNight();
                
                break;
            case GameState.Night:
                timer += Time.deltaTime;// Acciones para la noche
                gridController.Inputs();
                ToggleDayNight();
                break;
            case GameState.Paused:
                // Acciones para la pausa
                break;
            
            case GameState.Dawn:
                CheckCardLimit();
                
                break;
            case GameState.None: 
                break;
        }
    }
}
