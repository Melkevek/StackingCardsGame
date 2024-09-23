using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


    public class BoardController : MonoBehaviour
    {
        public GameObject cardPrefab;
        public GameObject maderaPrefab;
        public GameObject piedraPrefab;
        public GameObject pedernalPrefab;
        public GameObject cardEnemy;
        public GameObject cardZone;
        private GameObject board;
        private float cellSize = 3.0f; // Size of the grid cell
        public List<GameObject> instantiatedCards = new List<GameObject>(); // List to keep track of instantiated cards
        public LevelManager levelManager;
        internal int CardPrefabCount;
        
        void Start()
        {
            
            // Create a plane as a board
            board = GameObject.CreatePrimitive(PrimitiveType.Quad);
            board.transform.localScale = new Vector3(6, 2, 4); // Scale to make it 30x40 units
        }

        void Update()
        {
            
            
            
        }
       
       public void Inputs()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                board.transform.localScale += new Vector3(0.5f, 0, 0.5f);
                levelManager.cardsLimit += 5;
                Debug.Log(levelManager.cardsLimit);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                board.transform.localScale -= new Vector3(0.5f, 0, 0.5f);
                levelManager.cardsLimit -= 5;
                Debug.Log(levelManager.cardsLimit);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    Vector3 gridPosition = new Vector3(
                        Mathf.Round(hit.point.x / cellSize) * cellSize,
                        0.5f, Mathf.Round(hit.point.z / cellSize) * cellSize
                    );

                    GameObject card = Instantiate(cardPrefab, gridPosition, Quaternion.identity);
                    instantiatedCards.Add(card); // Add the instantiated card to the list
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    Vector3 gridPosition = new Vector3(
                        Mathf.Round(hit.point.x / cellSize) * cellSize,
                        0.5f, Mathf.Round(hit.point.z / cellSize) * cellSize
                    );

                    GameObject card = Instantiate(cardEnemy, gridPosition, Quaternion.identity);
                    //instantiatedCards.Add(card); // Add the instantiated card to the list
                }
            }
            if (Input.GetKeyDown(KeyCode.T))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    Vector3 gridPosition = new Vector3(
                        Mathf.Round(hit.point.x / cellSize) * cellSize,
                        0.5f, Mathf.Round(hit.point.z / cellSize) * cellSize
                    );

                    GameObject card = Instantiate(cardZone, gridPosition, Quaternion.identity);
                    instantiatedCards.Add(card); // Add the instantiated card to the list
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                foreach (GameObject card in instantiatedCards)
                {
                    card.transform.position = new Vector3(
                        Mathf.Round(card.transform.position.x / cellSize) * cellSize,
                        card.transform.position.y,
                        Mathf.Round(card.transform.position.z / cellSize) * cellSize
                    );
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
                if (hit == true)
                {
                if (hit.transform.CompareTag("Zone"))
                {
                    instantiatedCards.Remove(hit.transform.gameObject);
                    Destroy(hit.transform.gameObject);
                }
                }
            }
            if (Input.GetKeyDown(KeyCode.I))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    Vector3 gridPosition = new Vector3(
                        Mathf.Round(hit.point.x / cellSize) * cellSize,
                        0.5f, Mathf.Round(hit.point.z / cellSize) * cellSize
                    );

                    GameObject card = Instantiate(maderaPrefab, gridPosition, Quaternion.identity);
                    instantiatedCards.Add(card); // Add the instantiated card to the list
                }
            }
            if (Input.GetKeyDown(KeyCode.O))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    Vector3 gridPosition = new Vector3(
                        Mathf.Round(hit.point.x / cellSize) * cellSize,
                        0.5f, Mathf.Round(hit.point.z / cellSize) * cellSize
                    );

                    GameObject card = Instantiate(piedraPrefab, gridPosition, Quaternion.identity);
                    instantiatedCards.Add(card); // Add the instantiated card to the list
                }
            }
            if (Input.GetKeyDown(KeyCode.P))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    Vector3 gridPosition = new Vector3(
                        Mathf.Round(hit.point.x / cellSize) * cellSize,
                        0.5f, Mathf.Round(hit.point.z / cellSize) * cellSize
                    );

                    GameObject card = Instantiate(pedernalPrefab, gridPosition, Quaternion.identity);
                    instantiatedCards.Add(card); // Add the instantiated card to the list
                }
            }
        }
    }