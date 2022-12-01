using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerWorms : MonoBehaviour
{
    public GameObject collider;

    public int vida;
    bool moveng;
    [Header("Variavéis para primeiro efeito")]
    public GameObject fogo1;
    [Header("Variavéis para 2º efeito")]
    public GameObject wormFixer;
    public GameObject holofote1;
    public GameObject holofote2;
    [Header("Variavéis para 3º efeito")]
    public GameObject gamera;
    [Header("Variavéis para 4º efeito")]
    public GameObject chao1;
    public GameObject chao2;
    [Header("Variavéis para 5º efeito")]
    public GameObject crack;
    public WormBehaviour wmr;
    public GameObject bulletSpwn;
    [Header("Variavéis para ultimo efeito efeito")]
    public GameObject background;
    public GameObject door;
    // Use this for initialization
    void Start()
    {
        moveng = false;
        PlayerPrefs.SetString("level", "wr");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVida(int newvida)
    {
        Debug.Log(vida);
        vida -= newvida;
        if (vida == 6)
        {
            StartCoroutine(FirstTilter());

        }
        if (vida == 5)
        {
            holofote2.SetActive(true);
            holofote1.SetActive(true);

            StartCoroutine(Secondtilter());
        }
        if (vida == 4)
        {
            StartCoroutine(ThirdTilter());
        }
        if (vida == 3)
        {
            StartCoroutine(FourthTilter());
        }
        if (vida == 2)
        {
            StartCoroutine(FifthTilter());


        }
        if (vida == 1)
        {
            //  moveng = true;
            StartCoroutine(FinalTilter());
        }
        if (vida == 0)
        {
            print("cu");
            StartCoroutine(FinalTilter());

        }
    }
    IEnumerator FirstTilter()
    {
        Instantiate(fogo1, new Vector3(-5.08f, -0.57f, 6), transform.rotation);
        Instantiate(fogo1, new Vector3(1.25f, -0.57f, 6), transform.rotation);
        Instantiate(fogo1, new Vector3(2.56f, 0.17f, 6), transform.rotation);
        Instantiate(fogo1, new Vector3(-0.59f, -1.74f, 6), transform.rotation);
        Instantiate(fogo1, new Vector3(7.68f, -0.36f, 6), transform.rotation);
        Instantiate(fogo1, new Vector3(6.58f, -0.55f, 6), transform.rotation);
        Instantiate(fogo1, new Vector3(3.53f, 0.07f, 6), transform.rotation);
        Instantiate(fogo1, new Vector3(2.31f, -1.87f, 6), transform.rotation);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Secondtilter()
    {

        int qnt = Random.Range(4, 11);
        float xValue = Random.Range(-8.35f, 9.35f);
        if (qnt >= 4)
        {
            Debug.Log(qnt);


            xValue = Random.Range(-8.35f, 9.35f);
            Instantiate(wormFixer, new Vector3(xValue, 6, -7), transform.rotation);
            xValue = Random.Range(-8.35f, 9.35f);
            Instantiate(wormFixer, new Vector3(xValue, 6, -7), transform.rotation);
            xValue = Random.Range(-8.35f, 9.35f);
            Instantiate(wormFixer, new Vector3(xValue, 6, -7), transform.rotation);
            xValue = Random.Range(-8.35f, 9.35f);
            Instantiate(wormFixer, new Vector3(xValue, 6, -7), transform.rotation);
            if (qnt >= 5)
            {
                xValue = Random.Range(-8.35f, 9.35f);
                Instantiate(wormFixer, new Vector3(xValue, 6, 3), transform.rotation);
                if (qnt >= 6)
                {
                    xValue = Random.Range(-8.35f, 9.35f);
                    Instantiate(wormFixer, new Vector3(xValue, 6, 3), transform.rotation);
                    if (qnt >= 7)
                    {
                        xValue = Random.Range(-8.35f, 9.35f);
                        Instantiate(wormFixer, new Vector3(xValue, 6, 3), transform.rotation);
                        if (qnt >= 8)
                        {
                            xValue = Random.Range(-8.35f, 9.35f);
                            Instantiate(wormFixer, new Vector3(xValue, 6, 3), transform.rotation);
                            if (qnt >= 9)
                            {
                                xValue = Random.Range(-8.35f, 9.35f);
                                Instantiate(wormFixer, new Vector3(xValue, 6, 3), transform.rotation);
                                if (qnt == 10)
                                {
                                    xValue = Random.Range(-8.35f, 9.35f);
                                    Instantiate(wormFixer, new Vector3(xValue, 6, 3), transform.rotation);
                                }
                            }
                        }
                    }
                }
            }
        }
        gamera.transform.Translate(new Vector2(3, 0), Space.World);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Translate(new Vector2(-3, 0), Space.World);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Translate(new Vector2(3, 0), Space.World);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Translate(new Vector2(-3, 0), Space.World);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Translate(new Vector2(3, 0), Space.World);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Translate(new Vector2(-3, 0), Space.World);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Translate(new Vector2(3, 0), Space.World);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Translate(new Vector2(-3, 0), Space.World);
        gamera.transform.Rotate(0, 0, -4);
    }
    IEnumerator ThirdTilter()
    {
        gamera.transform.Rotate(0, 0, 34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -34);
        yield return new WaitForSeconds(0.1f);



    }
    IEnumerator FourthTilter()
    {
        
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        Rigidbody2D rbd1 = chao1.GetComponent<Rigidbody2D>();
        Rigidbody2D rbd2 = chao2.GetComponent<Rigidbody2D>();
        rbd1.bodyType = rbd2.bodyType = RigidbodyType2D.Dynamic;
        rbd1.gravityScale = rbd2.gravityScale = 2;
    }
    IEnumerator FifthTilter()
    {
        gamera.transform.Rotate(0, 0, 4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        gamera.transform.Rotate(0, 0, -4);
        yield return new WaitForSeconds(0.1f);
        crack.SetActive(true);
        gamera.AddComponent<KawaseBlur>();
    }
    IEnumerator SixthTilter()
    {

        while (moveng)
        {

            gamera.transform.Translate(new Vector2(-1, 0), Space.World);
            yield return new WaitForSeconds(0.3f);
            gamera.transform.Translate(new Vector2(-1, 0), Space.World);
            yield return new WaitForSeconds(0.3f);
            gamera.transform.Translate(new Vector2(-1, 0), Space.World);
            yield return new WaitForSeconds(0.3f);
            gamera.transform.Translate(new Vector2(1, 0), Space.World);
            yield return new WaitForSeconds(0.3f);
            gamera.transform.Translate(new Vector2(1, 0), Space.World);
            yield return new WaitForSeconds(0.3f);
            gamera.transform.Translate(new Vector2(1, 0), Space.World);
            yield return new WaitForSeconds(0.3f);


        }

    }
    IEnumerator FinalTilter()
    {
        collider.SetActive(false);
        bool tiltdobg;
        Rigidbody2D doorbd = door.GetComponent<Rigidbody2D>();
        doorbd.gravityScale = 1;
        tiltdobg = true;
        moveng = false;
        StopCoroutine(SixthTilter());
        //KawaseBlur kaw = gamera.GetComponent<KawaseBlur>();
        // kaw.enabled = false;
        gamera.transform.position = new Vector3(0.579034f, 0.9514174f, -10);
        //   gamera.transform.localEulerAngles = new Vector3(0, 0, 0);
        gamera.transform.position = new Vector3(0.579034f, 0.9514174f, -10);
        crack.SetActive(false);
        Destroy(bulletSpwn);
        WormBehaviour.SetDeath();
        yield return new WaitForSeconds(0.1f);
        Rigidbody2D rbd = background.GetComponent<Rigidbody2D>();
        rbd.gravityScale = 1;
        while (tiltdobg)
        {
            background.transform.Translate(new Vector2(0.1f, 0));
            yield return new WaitForSeconds(0.01f);
            background.transform.Translate(new Vector2(-0.1f, 0));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
