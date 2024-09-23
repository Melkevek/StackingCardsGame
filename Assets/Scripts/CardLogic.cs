using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelkevekGames
{
    
    public class CardLogic : MonoBehaviour
    {
        [SerializeField] private ResourceSO cardData;

        [SerializeField] private CraftingManager craftingManager;

        [SerializeField] private int iDSum;



        [SerializeField]private CardDrag cardDrag;
        //private bool dragging = false;
        //private float distanceToCamera;
        //[SerializeField]
        //private List<GameObject> stackedCards = new List<GameObject>();
        //[SerializeField] GameObject fatherCard; 
        //Vector3 originalPosition;
        [SerializeField] private CardLogic childCard;

        void Start()
        {
           
           if (cardDrag == null)
            {
                cardDrag = GetComponent<CardDrag>();
            }
           //originalPosition = transform.position;
        }
        //private void OnMouseDrag()
        //{
        //    dragging = true; 
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Vector3 rayPoint = ray.GetPoint(distanceToCamera);
        //    Vector3 offset = rayPoint - transform.position;

        //    // Mover todas las cartas apiladas
        //    foreach (GameObject card in stackedCards)
        //    {
        //        card.transform.position += offset;
        //    }
        //}
        //private void OnMouseUpAsButton()
        //{
        //    dragging = false;
        //}
        void OnMouseDown()
        {
            //distanceToCamera = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            //dragging = true;
            //if (dragging == false)
            //{
            if (transform.parent != null)
            {
                transform.parent.gameObject.GetComponent<CardLogic>().childCard = null;
                transform.parent.DetachChildren();
                //transform.position = originalPosition;
            }
            //}

            // Seleccionar todas las cartas apiladas sobre esta carta

            //for (int i = 0; i < transform.childCount; i++)
            //{
            //    var child = stackedCards[i].transform.GetChild(i);

            //}
        }

        //void OnMouseUp()
        //{
        //    dragging = false;
        //}

        void Update()
        {
            //if (dragging)
            //{

            //}
        }
        private void CardLogicU(GenericCardSO.CardType cardType)
        {
            switch (cardType)
            {
                case GenericCardSO.CardType.None:
                    break;
                case GenericCardSO.CardType.Enemy:
                    break;
                case GenericCardSO.CardType.Zone:
                    break;
                case GenericCardSO.CardType.Resource:
                    break;
                case GenericCardSO.CardType.Aventurer:

                    break;
                case GenericCardSO.CardType.Equipment:
                    break;
                default:
                    break;
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Colision con " + collision.gameObject.name);

            if (cardDrag.dragging && collision.gameObject.CompareTag("Card"))
            {
                Debug.Log("Colision con " + collision.gameObject.name);
                cardDrag.dragging = false;
                //gameObject.transform.parent = collision.transform;

                //Transform parentTransform = collision.transform;

                //// Crear un nuevo GameObject para ser el padre de las cartas apiladas si no existe
                //if (parentTransform.parent == null)
                //{
                //    GameObject stackParent = new GameObject("StackParent");
                //    parentTransform.SetParent(stackParent.transform);
                //}

                //// Apilar la carta actual sobre la carta con la que colisionó
                StackCard(collision.transform, 0.3f); // Ajusta el valor de yOffset según sea necesario
                collision.gameObject.GetComponent<CardLogic>().childCard = this;
                craftingManager.CheckResult(collision.gameObject.GetComponent<CardLogic>().cardData.cardID
                    + cardData.cardID);
                //gameObject.pare
                //craftingManager.CheckResult()
                //collision.gameObject.GetComponent<GenericCardSO>().stackedCards.Add(gameObject);
                //stackedCards.Add(collision.gameObject);


            }
        }

        // Función para apilar una carta sobre otra
        private void StackCard(Transform parentTransform, float yOffset)
        {
            //while (parentTransform.gameObject.GetComponent<CardLogic>().childCard == null)
            //{
            //    Debug.Log("Ignoranding colision");
            Physics2D.IgnoreCollision(parentTransform.GetComponent<BoxCollider2D>(),
                gameObject.GetComponent<BoxCollider2D>());
            //}

            // Calcular la nueva posición en la columna
            Vector3 newPosition = parentTransform.position;
            //newPosition.x -= xOffset;
            newPosition.y -= yOffset;

            // Asignar la nueva posición a la carta
            transform.position = newPosition;
            transform.SetParent(parentTransform);



            // Añadir la carta actual a la lista de cartas apiladas del padre
            //GenericCardSO parentCardScript = parentTransform.GetComponent<GenericCardSO>();
            //if (parentCardScript != null)
            //{
            //    parentCardScript.stackedCards.Add(transform);
            //}
        }
    }
}
