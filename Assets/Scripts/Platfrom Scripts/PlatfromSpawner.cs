using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromSpawner : MonoBehaviour{

    public static PlatfromSpawner instance;
    [SerializeField]
    private GameObject left_Platfrom, right_Platfrom;

    private float left_X_Min = -4.4f, left_X_Max = -2.8f, right_X_Min = 4.4f, right_X_Max = 2.8f;
    private float y_Treshold = 2.6f;
    private float last_Y;

    public int spawn_Count = 8;
    private int platfrom_Spawned;

    [SerializeField]
    private Transform platfrom_Parent;

    //More variable to spawn bird enemy
    [SerializeField]
    private GameObject bird;
    public float bird_Y = 5f;
    public float bird_X_Min = -2.3f, bird_X_Max = 2.3f;



    // Start is called before the first frame update
    void Awake() {
        if(instance == null)
        instance = this;
    }

    void Start(){
        last_Y = transform.position.y;
        SpawnPlatforms();
    }

    public void SpawnPlatforms(){

        Vector2 temp = Vector2.zero;
        GameObject newPlatform = null;

        for (int i =0; i< spawn_Count; i++){
            temp.y = last_Y;

            //we have event number
            if((platfrom_Spawned % 2) == 0){
                
                temp.x = Random.Range(left_X_Min, left_X_Max);
                newPlatform = Instantiate(right_Platfrom, temp, Quaternion.identity);

            }else{
                //if we have add number
                temp.x = Random.Range(right_X_Min, right_X_Max);
                newPlatform = Instantiate(left_Platfrom, temp, Quaternion.identity);
            }
            newPlatform.transform.parent = platfrom_Parent;

            last_Y += y_Treshold;
            platfrom_Spawned++;
        }
    if(Random.Range (0,2) > 0){
            SpawnBird();
    }

    } //spawn platfrom

    void SpawnBird(){
        Vector2 temp = transform.position;
        temp.x = Random.Range(bird_X_Min, bird_X_Max);
        temp.y += bird_Y;

        GameObject newBird = Instantiate(bird, temp, Quaternion.identity);
        newBird.transform.parent = platfrom_Parent;
        
    }
} //class
