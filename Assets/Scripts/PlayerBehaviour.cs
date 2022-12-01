using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    public float gravity = 1;
    public float speed = 1.5f; // velocidade do player
    public float jumpForce = 125; // altura do pulo do player
    public float hForce = 0; // força que se aplica quando anda
    private float fireRate = 0.5f; 
    private float nextFire;

    public bool canFire;
    public bool canTaco;
    public bool canJump;

    public AudioClip jumpEffect;
    public AudioClip fire;
    public AudioClip taco;

    private bool upStairs = false;
    private bool jump;
    private bool isDead = false;
    private bool crouched;
    private bool lookingUp;
    private bool tacada = false;

    private bool facingRight = true;
    private bool onGround = false;

    public GameObject bullet;
    public Transform shotSpawner;
    private Transform groudnCheck;

    private Animator an;
    private Rigidbody2D rb;
    private AudioSource ads;
    


    private int health;
    private int maxHealth;
    public float damageTime=1f;
    GameManager gameManeger;
    private bool tookDamage=false;

    // Use this for initialization
    void Start () {
        gameManeger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        ads = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        groudnCheck = gameObject.transform.Find("GroundCheck");
        an = GetComponent<Animator>();

        SetPlayerStatus();
        health = maxHealth;
        an.SetBool("NoWeapons", true);
    }
	
	// Update is called once per frame
	void Update () {
		if(!isDead)
        {
            onGround = Physics2D.Linecast(transform.position, groudnCheck.position, 1 << LayerMask.NameToLayer("Ground")); // se a linha do player ate o groundCheck estiver tocando na camada de nome "Ground"

            Shot(); // chaam função tiro
            Tacada();
            Jump();

            lookingUp = Input.GetButton("Up"); // quando apertar botão cima var "lookingUp = true
            crouched = Input.GetButton("Down"); // quando apertar botão baixo var "crouched = true

            an.SetBool("LookingUp", lookingUp); // animação recebe o valor da variavel lookingUp
            an.SetBool("Crouched", crouched); // animação recebe o valor da variavel crouched

            if((crouched || lookingUp) && onGround) // se agachado ou olhando para cima ou carregando e no chão, para de se movimentar
            {
                hForce = 0;
            }
        }
    }
    void Jump()
    {
        if (canJump)
        {
            if (onGround)
            {
                an.SetBool("Jump", false);
            }

            if (Input.GetButton("Jump") && onGround) // se player no chão e não esta carregando
            {
                jump = true;
                ads.clip = jumpEffect;
                ads.Play();

            }
            else if (Input.GetButtonUp("Jump"))
            {
                
                if (rb.velocity.y > 0)
                {
                    
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // diminui a velocidade no eixo de Y, para que pule em diferentes intensidades 
                }
            }
        }
            
    } // movimentos de pulo
    private void FixedUpdate()
    {
        if(!isDead)
        {
            if(!crouched && !lookingUp) // se agachado ou olhando para cima ou carregando e no chão, não recebe valor de movimento
            {
                hForce = Input.GetAxisRaw("Horizontal");

            }
            an.SetFloat("Speed", Mathf.Abs(hForce));// quando hforce for diferente de 0, transforma o valor em positivo e manda para a variavel da animação

            rb.velocity = new Vector2(hForce * speed, rb.velocity.y); // velocidade recebe a direção que o player esta andando

            if(hForce > 0 && !facingRight) // se andar para a direita e ele estiver virado para a esquerda
            {
                Flip();
            }
            else if(hForce < 0 && facingRight)
            {
                Flip();
            }
            if (upStairs)
            {
                transform.Translate(new Vector3(0, (Input.GetAxisRaw("Up") * speed) * Time.deltaTime, 0));
                rb.gravityScale = 0;
            }// se player esta na escada gravidade 0....
            else
            {
                rb.gravityScale = gravity;
            }//... se não gravidade 1

            if (jump)
            {
                an.SetBool("Jump", true);

                jump = false;

                rb.AddForce(Vector2.up * jumpForce);
            }
        }
    } // movimentação do player
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale; // scale recebe a escala do player

        scale.x *= -1; // inverte a posição atual do player

        transform.localScale = scale;
    } // flip do personagem
    void Shot()
    {
        
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && canFire) // verifica tempo atual de jogo, se for maior que proiximo tiro, atire
        {
            ads.clip = fire;
            ads.PlayScheduled(1);
            nextFire = Time.time + fireRate;
            an.SetTrigger("Shot");
            GameObject tempBullet = Instantiate(bullet, shotSpawner.position, shotSpawner.rotation);
            if (!facingRight && !lookingUp)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 180); // muda a rotação no eixo z, pra poder atirar pra traz
            }
            else if (!facingRight && lookingUp)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 90); // muda a rotação no eixo z, permitindo o tiro seguir para cima
            }
            else if (facingRight && lookingUp)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, 90); // muda a rotação no eixo z, permitindo o tiro seguir para cima
            }
            if (crouched && !onGround)
            {
                tempBullet.transform.eulerAngles = new Vector3(0, 0, -90); // muda a rotação no eixo z, permitindo o tiro seguir para baixo
            }

            if(canFire)
            {
                an.SetBool("NoWeapons", false);
            }
        }
    } // mecanica de tiro
    void Tacada()
    {
        if (canTaco)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                ads.clip = taco;
                ads.PlayScheduled(1);
                an.SetTrigger("Tacada");
                StartCoroutine(TacoCD());
            }
        }
    }

    void PlayerLift(bool lifter)
    {
        upStairs = lifter;
    }
    public void SetPlayerStatus()
    {
        maxHealth = gameManeger.health;
        fireRate = gameManeger.fireRate;
    }

    void UpdateHealthUi()
    {
        FindObjectOfType<GameManager>().UpdateHealthUi(health);
    }
    private void OnTriggerEnter2D(Collider2D trigg)
    {
        if(trigg.CompareTag("Enemy") && !tookDamage)
        {
            StartCoroutine(TookDamagePlayer());
        }
    }

    IEnumerator TookDamagePlayer()
    {
        tookDamage = true;
        health--;
        UpdateHealthUi();
        if(health<= 0)
        {
            isDead = true;
            an.SetTrigger("Death");
            SceneManager.LoadScene(4);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 10);
            Physics2D.IgnoreLayerCollision(9, 12);
            Physics2D.IgnoreLayerCollision(9, 13);
            for (float i = 0; i < damageTime; i+= 0.2f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(0.1f);
                GetComponent<SpriteRenderer>().enabled = true;
                yield return new WaitForSeconds(0.1f);
            }
            Physics2D.IgnoreLayerCollision(9, 10,false);
            Physics2D.IgnoreLayerCollision(9, 12,false);
            Physics2D.IgnoreLayerCollision(9, 13,false);
            tookDamage = false;
        }
    }

    IEnumerator TacoCD()
    {
        tacada = true;
        yield return new WaitForSeconds(1.2f);
        tacada = false;
        canTaco = true;
    }
}
