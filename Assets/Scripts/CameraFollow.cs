using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public float xMargin = 1f; // Distância no eixo x, o jogador pode mover-se antes da câmera seguir.
        public float yMargin = 1f; // Distância no eixo y, o jogador pode mover-se antes da câmera seguir.
        public float xSmooth = 8f; // Quão suavemente a câmera alcança com o movimento do alvo no eixo x.
        public float ySmooth = 8f; // Quão suavemente a câmera alcança com o movimento do alvo no eixo y.
        public Vector2 maxXAndY; // As coordenadas máximas x e y que a câmera pode ter.
        public Vector2 minXAndY; // As coordenadas mínimas x e y que a câmera pode ter.

        private Transform m_Player; // Reference to the player's transform.


        private void Awake()
        {
            // Setting up the reference.
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        }


        private bool CheckXMargin()
        {
            // Retorna verdadeiro se a distância entre a câmera eo jogador no eixo x for maior que a margem x.
            return Mathf.Abs(transform.position.x - m_Player.position.x) > xMargin;
        }


        private bool CheckYMargin()
        {
            // Retorna verdadeiro se a distância entre a câmera e o jogador no eixo y for maior que a margem y.
            return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
        }


        private void Update()
        {
            TrackPlayer();
        }


        private void TrackPlayer()
        {
            // Por padrão, as coordenadas x e y do alvo da câmera são as coordenadas x e y atuais.
            float targetX = transform.position.x;
            float targetY = transform.position.y;

            // Se o jogador se moveu para além da margem x ...
            if (CheckXMargin())
            {
                // ... a coordenada x do alvo deve ser um Lerp entre a posição x atual da câmera e a posição x atual do jogador.
                targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth*Time.deltaTime);
            }

            // Se o jogador se moveu para além da margem Y ...
            if (CheckYMargin())
            {
                // ... a coordenada do alvo y deve ser um Lerp entre a posição atual da câmera e a posição atual do jogador.
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth*Time.deltaTime);
            }

            // As coordenadas x e y do alvo não devem ser maiores que o máximo ou menor do que o mínimo.
            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

            // Defina a posição da câmera para a posição de destino com o mesmo componente z.
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
