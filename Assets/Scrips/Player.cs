using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Enemy enemy;

    public Animator anim;

    public float atktime;

    public bool attacking = false;
    bool canJump;

    void Start()
    {
                
    }

    void Update()
    {
        // Movimiento del jugador
        if ((Input.GetKey("left")) || (Input.GetKey(KeyCode.A)))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
        }
        if ((Input.GetKey("right")) || (Input.GetKey(KeyCode.D)))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
        }
        if ((Input.GetKeyDown("up") && canJump) /*|| (Input.GetKey(KeyCode.W) && canJump)*/ || (Input.GetKey(KeyCode.Space) && canJump))
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
        }

        // Curacion del jugador
        if ((Input.GetKeyDown(KeyCode.Q) && (GameController.cristals > 0) && (GameController.lifes < 8)))
        {
            GameController.lifes += 1;
            GameController.cristals -= 1;
        }

        // Ataque del jugador
        if ((Input.GetKey(KeyCode.W) /*Input.GetMouseButtonDown(0)*/ && !attacking))
        {
            StartCoroutine(Attacking(atktime));            
        }

        if (transform.position.y < -5)
        {
            GameObject.Destroy(this.gameObject);
        }
                
    }

    public IEnumerator Attacking(float valcrono)
    {
        attacking = true;
        anim.SetFloat("Atk", 2);
        
        yield return new WaitForSeconds(valcrono);

        attacking = false;
        anim.SetFloat("Atk", 0);
    }
    public IEnumerator Damaged(float valcrono)
    {        
        anim.SetFloat("dmg", 2);
        yield return new WaitForSeconds(valcrono);        
        anim.SetFloat("dmg", 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Colision suelo
        if (collision.transform.tag == "ground")
        {
            canJump = true;
        }

        // Colision enemigo1
        if (collision.transform.tag == "enemy1" && !attacking && anim.GetFloat("Atk") < 1)
        {            
            GameController.lifes -= 1;
            StartCoroutine(Damaged(1));
        }
        // Colision muerte enemigo1
        if (collision.transform.tag == "enemy1" && attacking && anim.GetFloat("Atk")>1)
        {
            collision.gameObject.SetActive(false);
        }
        // Colision enemigo2
        if (collision.transform.tag == "enemy2")
        {
            if (GameController.lifes > 2)
            {
                GameController.lifes -= 2;
                StartCoroutine(Damaged(1));
            }
            else
            {
                GameController.lifes = 0;
            }
            
        }

        // Colision cristal
        if (collision.transform.tag == "powerup")
        {
            GameController.cristals += 1;
        }

    }

    // Muerte del jugador
    public void Dead()
    {
        GameObject.Destroy(this.gameObject);
    }
}
