using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject botaoPause;
    
    void Update()
    {
        
        // Colocar aqui que a seta voltar do celular tambem vai servir para pausar

        if(Input.GetKeyDown(KeyCode.Escape)){

            if(GameIsPaused){

                Resume();
            }else{  

                Pause();
            }



        }

    }
        public void Resume(){
            
            pauseMenuUI.SetActive(false);
            botaoPause.SetActive(true);
            Camera.main.orthographicSize = 5.0f;
            Time.timeScale = 1f; // Volta ao normal cena
            GameIsPaused = false;


        }


        public void Pause(){
            botaoPause.SetActive(false);
            pauseMenuUI.SetActive(true);
            Camera.main.orthographicSize = 3.0f;
            Time.timeScale = 0f; // Congela cena
            GameIsPaused = true;

        }


        public void LoadMenu(){

            Time.timeScale = 1f; // Volta ao normal cena
            Camera.main.orthographicSize = 5.0f;
            SceneManager.LoadScene("Menu");

        }

        public void Quit(){

            Application.Quit();
        }
    
}
