using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour{
    // Start is called before the first frame update
    private GameObject[] bgs;
    private float height;
    private float height_Y_Pos;

    void Awake(){
        bgs = GameObject.FindGameObjectsWithTag("BG");
    }

    void Start(){
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;

        height_Y_Pos = bgs[0].transform.position.y;

        for (int i = 1; i < bgs.Length; i++){
            if(bgs[i].transform.position.y > height_Y_Pos)
                height_Y_Pos = bgs[i].transform.position.y;
        }

    }

    void OnTriggerEnter2D(Collider2D target){

        if(target.tag == "BG"){
            // we collided with the heghest Y BG
            if(target.transform.position.y >= height_Y_Pos){
                Vector3 temp = target.transform.position;

                for(int i = 0; i < bgs.Length; i++){
                    
                    //if the BG at "1" index NOT active in the hierarchy
                    if(!bgs[i].activeInHierarchy){
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        height_Y_Pos = temp.y;
                    }
                }
            }
        }

    } //on Trigger Enter

} //class

