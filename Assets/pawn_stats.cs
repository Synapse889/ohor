using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn_stats : MonoBehaviour {
    public double strength;
    public double sight;
    public float speed;
    public double hunger_rate;

    public double hunger = 100;

    private bool move;
    public GameObject point;
    private Vector3 target;

    // Use this for initialization
    void Start () {
        strength = Random.Range(1, 5);
        sight = Random.Range(1, 5);
        speed = Random.Range(1, 5);
        hunger_rate = Random.Range(1, 5);

        
    }
	
	// Update is called once per frame
	void Update () {
        hunger -= hunger_rate * 0.01;

        if(hunger < 0)
        {
            Object.Destroy(gameObject);
        }

        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            if(move == false)
            {
                move = true;
            }
            Instantiate(point, target, Quaternion.identity);
        }
        if(move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        }
	}
}
