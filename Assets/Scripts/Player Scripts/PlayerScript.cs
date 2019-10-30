using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour{

    private Rigidbody2D myBody;

    private float ScreenWidth;

    public float move_Speed = 2f;

    public float normal_Push = 10f;
    public float extra_Push = 14f;

    private bool initial_Push;
    private int push_Count;
    private bool player_Died;

    void Awake(){
        myBody = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate(){
        Move();
    }

    void Move(){

        if(player_Died)
            return;

        //Input With Keyboard
        // if(Input.GetAxisRaw("Horizontal") > 0 ){
        //     myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);
        // }else if (Input.GetAxisRaw("Horizontal") < 0){
        //     myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);
        // }

        //Input With TouchScreen
        int i = 0;
        while (i<Input.touchCount){
            if(Input.GetTouch(i).position.x > ScreenWidth / 2){
                //Move Right
                myBody.velocity = new Vector2(move_Speed, myBody.velocity.y);
            }if(Input.GetTouch (i).position.x < ScreenWidth / 2){
                //Move left
                myBody.velocity = new Vector2(-move_Speed, myBody.velocity.y);
            }
            ++i;
        }

    } //player Movement

    void OnTriggerEnter2D (Collider2D target){

        if (player_Died)
            return;

        if(target.tag == "ExtraPush"){
            if(!initial_Push){
                initial_Push = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                target.gameObject.SetActive(false);

                //Sound Manager
                SoundManager.instance.JumpSoundFX();


                //exit from the on trigger enter because pf initial push
                return;
            } //initial push

            //outside of the initial push

        } //because of the initial push

        if (target.tag == "NormalPush"){

            myBody.velocity = new Vector2(myBody.velocity.x, normal_Push);
            target.gameObject.SetActive(false);
            push_Count++;

            //SoundManager
            SoundManager.instance.JumpSoundFX();

            //PointScore
            score.scoreValue +=1;
        }

        if (target.tag == "ExtraPush"){

            myBody.velocity = new Vector2(myBody.velocity.x, extra_Push);
            target.gameObject.SetActive(false);
            push_Count++;

            SoundManager.instance.JumpSoundFX();

            //PointScore
            score.scoreValue += 2;
        }

        if(push_Count == 2){
            push_Count = 0;
            PlatfromSpawner.instance.SpawnPlatforms();

        }

        if(target.tag == "FallDown" || target.tag == "Bird"){
            player_Died = true;

            //Sound Manager
            SoundManager.instance.GameOverSoundFX();
            //Game Manager
            GameManager.instance.RestartGame();

            // //Restart Poin
            // score.scoreValue = 0;
        }

    }//on Trigger Enter

} //class
