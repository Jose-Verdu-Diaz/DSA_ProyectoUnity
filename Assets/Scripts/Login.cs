using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update

    public void LoadMenu(){
        
        SceneManager.LoadScene("Menu");

    }

    public void LoadRegistrar(){
        
        SceneManager.LoadScene("Registrar");

    }


}
