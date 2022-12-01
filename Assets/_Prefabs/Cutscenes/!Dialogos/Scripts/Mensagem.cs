using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensagem : MonoBehaviour {

    public GameObject panelGadget; // variavel que desativa painel de armas quando uma conversa se inicia
    public GameObject panelBox; // caixa de dialogo que recebe 
    public TextAsset arquivo; // arquivo .txt com as falas

    private string textoArquivo; // string que possibilita a animação "esquever"
    public float LPS,tempo; //letras por segundo
    public float speedPlayer;
    int i;

    PlayerBehaviour plyaer; ////////////////////////////////////////////////////////

    public Text[] Baloes; // "balões" simbolizano a conversa de cada personagem
    public Text balaoAtual; // informa qual texto esta sendo impresso no momento
    public GameObject[] Images;
    public GameObject imagemAtual;

    public bool dialogoConcluido;
    public bool colidiu;

    // Use this for initialization
    void Start () {
        plyaer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();///////
        dialogoConcluido = false;
        textoArquivo = arquivo.ToString();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Baloes[0].text = "";
            Baloes[1].text = "";
            Baloes[2].text = "";
        }

        if (colidiu)
        {
            Habilitar();
            plyaer.speed = 0;
            LeTextoArquivo();
        }
        if(!colidiu)
        {
            Desabilitar();
            plyaer.speed = speedPlayer;
        }

    }

    public void Habilitar()
    {
        panelGadget.SetActive(false);
        panelBox.SetActive(true);
    } // habilita a aba de dialogo

    public void Desabilitar()
    {
        panelGadget.SetActive(true);
        panelBox.SetActive(false);
    } // desabilida a aba de dialogo

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            colidiu = true;
            Habilitar();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        colidiu = false;
        Desabilitar();
        Destroy(gameObject);
    }


    // verifica a sequencia de falas e imprime na ordem
    public void LeTextoArquivo()
    { 
        tempo += Time.deltaTime;
        if (tempo > (1f / LPS) && i < textoArquivo.Length)
        {
            if (textoArquivo[i] != '#' || Input.GetKeyDown(KeyCode.Q)) // se o dialogo não acabou
            {
                if (textoArquivo[i] != '¨' || Input.GetKeyDown(KeyCode.Q)) // se não pulou de linha
                {
                    if (textoArquivo[i] == '-') // leia o que tem depois do -
                    {
                        i++;
                        int novoBalao = textoArquivo[i];

                        novoBalao -= 48; // metodo loco de transformar numeros em char

                        balaoAtual = Baloes[novoBalao];

                        if (textoArquivo[i] == '0')
                        {
                            Images[0].SetActive(true);
                            Images[1].SetActive(false);
                            Images[2].SetActive(false);
                        }
                        if (textoArquivo[i] == '1')
                        {
                            Images[0].SetActive(false);
                            Images[1].SetActive(true);
                            Images[2].SetActive(false);
                        }
                        if (textoArquivo[i] == '2')
                        {
                            Images[0].SetActive(false);
                            Images[1].SetActive(false);
                            Images[2].SetActive(true);
                        }
                    }
                   
                    else if (textoArquivo[i] != '0' && textoArquivo[i] != '1' && textoArquivo[i] != '2' && textoArquivo[i] != '#' && textoArquivo[i] != '¨')
                    {
                        balaoAtual.text += textoArquivo[i];
                    }
                    tempo = 0;
                    i++;
                }
            }
            if(textoArquivo[i] == '#')
                colidiu = false;
        }

    }
}
