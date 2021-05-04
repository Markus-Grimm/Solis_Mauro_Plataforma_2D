using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Movimiento y camara
    public GameObject player;
    public new Camera camera;

    //Interfaz, derrota y victoria
    public Text gamedefeat;
    public Text gamevictory;
    public bool lose;

    //Interfaz vida
    public static int lifes;
    public GameObject life1, life2, life3, life4, life5, life6, life7, life8,
        cristals1, cristals2, cristals3, cristals4, cristals5, cristals6, cristals7, cristals8;
    public Player Player;

    //Interfaz cristales
    public static int cristals;

    //Generador de niveles
    public GameObject[] Lvls;
    public float triggerlevel = 12.8f;
    public float savepointspawn = 12.8f;

    void Start()
    {
        lose = false;

        gamedefeat.text = " ";
        gamevictory.text = " ";


        //      Contador de vida
        lifes = 4;                                          
        life1.gameObject.SetActive(true);                   
        life2.gameObject.SetActive(true);                     
        life3.gameObject.SetActive(true);                   
        life4.gameObject.SetActive(true);                   
        life5.gameObject.SetActive(false);                  
        life6.gameObject.SetActive(false);                  
        life7.gameObject.SetActive(false);                  
        life8.gameObject.SetActive(false);

        //      Contador de cristales
        cristals = 0;
        cristals1.gameObject.SetActive(false);
        cristals2.gameObject.SetActive(false);
        cristals3.gameObject.SetActive(false);
        cristals4.gameObject.SetActive(false);
        cristals5.gameObject.SetActive(false);
        cristals6.gameObject.SetActive(false);
        cristals7.gameObject.SetActive(false);
        cristals8.gameObject.SetActive(false);

    }

    
    void Update()
    {
        //      Interfaz muerte jugador, reiniciar y volver al menu
        if (player == null)
        {
            if (!lose)
            {
                lose = true;
                gamedefeat.text = "Game Over\nPress R to restart or E to exit";
            }
            if (lose)
            {
                if (Input.GetKeyDown("r"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                if (Input.GetKeyDown("e"))
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }            
        }
        else
        {
            camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);
        }

        //      Contador de vida
        if (lifes > 8)
        {
            lifes = 8;
        }
        switch (lifes)
        {
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                life6.gameObject.SetActive(false);
                life7.gameObject.SetActive(false);
                life8.gameObject.SetActive(false);
                break;

            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                life6.gameObject.SetActive(false);
                life7.gameObject.SetActive(false);
                life8.gameObject.SetActive(false);
                break;

            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);                
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                life6.gameObject.SetActive(false);
                life7.gameObject.SetActive(false);
                life8.gameObject.SetActive(false);
                break;

            case 4:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(false);
                life6.gameObject.SetActive(false);
                life7.gameObject.SetActive(false);
                life8.gameObject.SetActive(false);
                break;

            case 5:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(true);
                life6.gameObject.SetActive(false);
                life7.gameObject.SetActive(false);
                life8.gameObject.SetActive(false);
                break;

            case 6:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(true);
                life6.gameObject.SetActive(true);
                life7.gameObject.SetActive(false);
                life8.gameObject.SetActive(false);

                break;

            case 7:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(true);
                life6.gameObject.SetActive(true);
                life7.gameObject.SetActive(true);
                life8.gameObject.SetActive(false);
                break;

            case 8:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(true);
                life6.gameObject.SetActive(true);
                life7.gameObject.SetActive(true);
                life8.gameObject.SetActive(true);
                break;

            case 0:                
                Player.Dead();
                lifes = -1;
                break;

            default:
                break;
        }
        //      Contador de cristales
        if (cristals > 8)
        {
            cristals = 8;
        }
        switch (cristals)
        {
            case 0:
                cristals1.gameObject.SetActive(false);
                cristals2.gameObject.SetActive(false);
                cristals3.gameObject.SetActive(false);
                cristals4.gameObject.SetActive(false);
                cristals5.gameObject.SetActive(false);
                cristals6.gameObject.SetActive(false);
                cristals7.gameObject.SetActive(false);
                cristals8.gameObject.SetActive(false);
                break;

            case 1:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(false);
                cristals3.gameObject.SetActive(false);
                cristals4.gameObject.SetActive(false);
                cristals5.gameObject.SetActive(false);
                cristals6.gameObject.SetActive(false);
                cristals7.gameObject.SetActive(false);
                cristals8.gameObject.SetActive(false);
                break;

            case 2:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(true);
                cristals3.gameObject.SetActive(false);
                cristals4.gameObject.SetActive(false);
                cristals5.gameObject.SetActive(false);
                cristals6.gameObject.SetActive(false);
                cristals7.gameObject.SetActive(false);
                cristals8.gameObject.SetActive(false);
                break;

            case 3:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(true);
                cristals3.gameObject.SetActive(true);
                cristals4.gameObject.SetActive(false);
                cristals5.gameObject.SetActive(false);
                cristals6.gameObject.SetActive(false);
                cristals7.gameObject.SetActive(false);
                cristals8.gameObject.SetActive(false);
                break;

            case 4:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(true);
                cristals3.gameObject.SetActive(true);
                cristals4.gameObject.SetActive(true);
                cristals5.gameObject.SetActive(false);
                cristals6.gameObject.SetActive(false);
                cristals7.gameObject.SetActive(false);
                cristals8.gameObject.SetActive(false);
                break;

            case 5:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(true);
                cristals3.gameObject.SetActive(true);
                cristals4.gameObject.SetActive(true);
                cristals5.gameObject.SetActive(true);
                cristals6.gameObject.SetActive(false);
                cristals7.gameObject.SetActive(false);
                cristals8.gameObject.SetActive(false);
                break;

            case 6:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(true);
                cristals3.gameObject.SetActive(true);
                cristals4.gameObject.SetActive(true);
                cristals5.gameObject.SetActive(true);
                cristals6.gameObject.SetActive(true);
                cristals7.gameObject.SetActive(false);
                cristals8.gameObject.SetActive(false);

                break;

            case 7:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(true);
                cristals3.gameObject.SetActive(true);
                cristals4.gameObject.SetActive(true);
                cristals5.gameObject.SetActive(true);
                cristals6.gameObject.SetActive(true);
                cristals7.gameObject.SetActive(true);
                cristals8.gameObject.SetActive(false);
                break;

            case 8:
                cristals1.gameObject.SetActive(true);
                cristals2.gameObject.SetActive(true);
                cristals3.gameObject.SetActive(true);
                cristals4.gameObject.SetActive(true);
                cristals5.gameObject.SetActive(true);
                cristals6.gameObject.SetActive(true);
                cristals7.gameObject.SetActive(true);
                cristals8.gameObject.SetActive(true);
                Victory();
                break;

            default:
                break;
        }

        // Generador de niveles
        while (player != null && triggerlevel < player.transform.position.x)
        {
            int indblock = Random.Range(0, Lvls.Length - 1);

            if (triggerlevel < 0)
            {
                indblock = 0;
            }
            GameObject ObjBlock = Instantiate(Lvls[indblock]);
            ObjBlock.transform.SetParent(this.transform);
            Block block = ObjBlock.GetComponent<Block>();
            ObjBlock.transform.position = new Vector2(triggerlevel + 19.2f, 0);
            triggerlevel += 19.2f;
        }

    }

    public void Victory()
    {
        gamevictory.text = "Congratulations, you found the eight crystals you need.\nPress R to restart or E to exit.";
        player.GetComponent<Player>().enabled = false;

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
