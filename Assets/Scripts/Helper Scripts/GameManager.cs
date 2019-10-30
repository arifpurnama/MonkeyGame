using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public static GameManager instance;

    // Start is called before the first frame update
    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    public void RestartGame(){
        Invoke("LoadGameplay", 3f);
        
    }

    void LoadGameplay(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");

        //Restart Poin
        score.scoreValue = 0;
    }

} //class
