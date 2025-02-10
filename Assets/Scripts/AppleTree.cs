using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject branchPrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that th AppleTree will change direction
    public float changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float itemDropDelay = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start dropping apples
        Invoke("DropItem", 2f);

    }

    void DropItem(){

        GameObject item;

        if (Random.value < 0.2f){
           item = Instantiate<GameObject>(branchPrefab);            

        }
        else{
            item = Instantiate<GameObject>(applePrefab);

        }
        
        item.transform.position = transform.position;
        Invoke("DropItem", itemDropDelay);

    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge){
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed); // Move left
        //}
        //else if (Random.value < changeDirChance){
        //    speed *= 1; // Change Direction
        }

    }

    void FixedUpdate(){

        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance){
            speed *= -1; // Change direction
        }

    }
}
