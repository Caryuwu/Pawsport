using UnityEngine;
using System.Collections;
using TMPro;

namespace DialogueSystemJadsa
{
    public class minijuego : MonoBehaviour
    {
        public GameObject MinijuegoCartas;
        public GameObject marcaUI; // La marca visual
        private bool enColision = false;

        void Update()
        {
            if (enColision && Input.GetMouseButtonDown(1))
            {
                StartMinijuego();
            }
        }

        void StartMinijuego()
        {
            MinijuegoCartas.SetActive(true);
            marcaUI.SetActive(false); // Desaparece la marca al empezar el juego // Pausa el juego principal
        }

        public void EndMinijuego()
        {
            MinijuegoCartas.SetActive(false);
            marcaUI.SetActive(true); // Reaparece la marca al terminar el juego
            Time.timeScale = 1f; // Reanuda el juego principal
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                enColision = true;
                marcaUI.SetActive(true); // Aparece la marca al acercarse
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                enColision = false;
                marcaUI.SetActive(false); // Desaparece la marca al alejarse
            }
        }
    }
}
