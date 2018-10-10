using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

    public float speed = 0.3f;
    Vector2 dir = Vector2.up;
    bool ate;
    List<Transform> tail = new List<Transform>();
    public GameObject tailPrefab;
    public Action OnLose;
    public int getscore;
    public Text score;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Move", speed, speed);
		
	}
    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        if (ate)
        {
            GameObject body = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, body.transform);

            ate = false;
        }
        else if(tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey("up") && dir != Vector2.down)
        {
            dir = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey("down") && dir != Vector2.up)
        {
            dir = Vector2.down;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left") && dir != Vector2.right)
        {
            dir = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right") && dir != Vector2.left)
        {
            dir = Vector2.right;
        }
    }

        void OnTriggerEnter2D(Collider2D coll)
        {

        if (coll.name.StartsWith("Food"))
        {
            Destroy(coll.gameObject);
            ate = true;
            getscore++;
            score.text = "得分：" + getscore;
            speed -= 0.02f;
            if (speed < 0.08f)
                speed = 0.08f;

        }
        else
        {
            SceneManager.LoadScene(0);
        
        }
        
         }

}
