using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public float xMargin = 1f; // Dist�ncia no eixo x, o jogador pode mover-se antes da c�mera seguir.
        public float yMargin = 1f; // Dist�ncia no eixo y, o jogador pode mover-se antes da c�mera seguir.
        public float xSmooth = 8f; // Qu�o suavemente a c�mera alcan�a com o movimento do alvo no eixo x.
        public float ySmooth = 8f; // Qu�o suavemente a c�mera alcan�a com o movimento do alvo no eixo y.
        public Vector2 maxXAndY; // As coordenadas m�ximas x e y que a c�mera pode ter.
        public Vector2 minXAndY; // As coordenadas m�nimas x e y que a c�mera pode ter.

        private Transform m_Player; // Reference to the player's transform.


        private void Awake()
        {
            // Setting up the reference.
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        }


        private bool CheckXMargin()
        {
            // Retorna verdadeiro se a dist�ncia entre a c�mera eo jogador no eixo x for maior que a margem x.
            return Mathf.Abs(transform.position.x - m_Player.position.x) > xMargin;
        }


        private bool CheckYMargin()
        {
            // Retorna verdadeiro se a dist�ncia entre a c�mera e o jogador no eixo y for maior que a margem y.
            return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
        }


        private void Update()
        {
            TrackPlayer();
        }


        private void TrackPlayer()
        {
            // Por padr�o, as coordenadas x e y do alvo da c�mera s�o as coordenadas x e y atuais.
            float targetX = transform.position.x;
            float targetY = transform.position.y;

            // Se o jogador se moveu para al�m da margem x ...
            if (CheckXMargin())
            {
                // ... a coordenada x do alvo deve ser um Lerp entre a posi��o x atual da c�mera e a posi��o x atual do jogador.
                targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth*Time.deltaTime);
            }

            // Se o jogador se moveu para al�m da margem Y ...
            if (CheckYMargin())
            {
                // ... a coordenada do alvo y deve ser um Lerp entre a posi��o atual da c�mera e a posi��o atual do jogador.
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth*Time.deltaTime);
            }

            // As coordenadas x e y do alvo n�o devem ser maiores que o m�ximo ou menor do que o m�nimo.
            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            // Defina a posi��o da c�mera para a posi��o de destino com o mesmo componente z.
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
