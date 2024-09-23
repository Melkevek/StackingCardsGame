using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MelkevekGames
{
    public class CardDrag : MonoBehaviour
    {
        public bool dragging = false;
        private Vector3 offset;

        void OnMouseDown()
        {
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            offset.z = 0; // Asegúrate de que el offset en z sea 0
            dragging = true;
        }

        void OnMouseUp()
        {
            dragging = false;
        }

        void Update()
        {
            if (dragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // Asegúrate de que la posición en z sea 0
                transform.position = mousePosition - offset;
            }
        }
    }
}
