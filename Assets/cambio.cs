using System.Collections;
using UnityEngine;

namespace DialogueSystemJadsa
{ 
     public class cambio : MonoBehaviour{
        public Sprite Atras; // Sprite de la parte trasera de las cartas
    public SpriteRenderer[] Cartas; // Lista de las cartas
    public int[] IDs; // Lista de IDs para identificar pares

    private Sprite[] Cara; // Sprites originales de las cartas (parte frontal)
    public int score = 0;

    private SpriteRenderer Primera; // Primera carta seleccionada
    private SpriteRenderer Segunda; // Segunda carta seleccionada
    private int PrimeraID; // ID de la primera carta seleccionadaS
    private int SegundaID; // ID de la segunda carta seleccionada

    public int ParejasTotal;
    public minijuego minijuego;

    private bool puedeSeleccionar = true; // Controla si se pueden seleccionar cartas

    void Start()
    {
        Cara = new Sprite[Cartas.Length];

        for (int i = 0; i < Cartas.Length; i++)
        {
            Cara[i] = Cartas[i].sprite;

            // Añade un collider si no hay uno
            if (Cartas[i].GetComponent<Collider2D>() == null)
            {
                Cartas[i].gameObject.AddComponent<BoxCollider2D>();
            }

            // Asigna el evento de clic para cada carta
            int index = i;
            Cartas[i].gameObject.AddComponent<UnityEngine.UI.Button>().onClick.AddListener(() => RevealCard(Cartas[index], IDs[index]));
        }
    }

    // Voltea todas las cartas boca abajo
    public void ChangeAllSprites()
    {
        for (int i = 0; i < Cartas.Length; i++)
        {
            Cartas[i].sprite = Atras;
            Cartas[i].gameObject.SetActive(true);
        }
        score = 0;
        Reset();
    }

    // Revela una carta al hacer clic
    public void RevealCard(SpriteRenderer card, int id)
    {
        if (!puedeSeleccionar) return; // Bloquea el proceso si ya hay dos cartas seleccionadas

        if (Primera == null)
        {
            Primera = card;
            PrimeraID = id;
            Primera.sprite = Cara[System.Array.IndexOf(Cartas, Primera)];
        }
        else if (Segunda == null && card != Primera)
        {
            Segunda = card;
            SegundaID = id;
            Segunda.sprite = Cara[System.Array.IndexOf(Cartas, Segunda)];

            // Bloquea la selección mientras se comparan las cartas
            puedeSeleccionar = false;

            if (PrimeraID == SegundaID)
            {
                Debug.Log("¡Par encontrado!");
                score++;
                StartCoroutine(DesactivarCartas());
            }
            else
            {
                StartCoroutine(EsconderCartas());
            }
        }

        // Si encuentra todos los pares, termina el juego
        if (score == ParejasTotal)
        {
            minijuego.MinijuegoCartas.SetActive(false);
            Debug.Log("¡Juego completo!");
        }
    }

    // Desactiva las cartas si son pares
    IEnumerator DesactivarCartas()
    {
        yield return new WaitForSeconds(1f);

        Primera.gameObject.SetActive(false);
        Segunda.gameObject.SetActive(false);

        Reset(); // Limpia las referencias y permite seleccionar de nuevo
    }

    // Voltea las cartas si no son pares
    IEnumerator EsconderCartas()
    {
        yield return new WaitForSeconds(1f);

        Primera.sprite = Atras;
        Segunda.sprite = Atras;

        Reset(); // Limpia las referencias y permite seleccionar de nuevo
    }

    // Resetea las referencias para permitir una nueva selección
    void Reset()
    {
        Primera = null;
        Segunda = null;
        puedeSeleccionar = true; // Permite que el jugador seleccione nuevas cartas
    }
    }}