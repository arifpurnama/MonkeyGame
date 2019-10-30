using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour{

    public Text scoreText;
    

    private bool isDead = false;
    public static int scoreValue = 0;
    // // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dead
        if(isDead)
        return;

        scoreText.text = scoreValue.ToString();
    }

    
}
