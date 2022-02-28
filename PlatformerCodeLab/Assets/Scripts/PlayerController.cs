using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(KeyCode.W, 0, moveSpeed);
        Move(KeyCode.S, 0, -moveSpeed);
        Move(KeyCode.A, -moveSpeed, 0);
        Move(KeyCode.D, moveSpeed, 0);
    }

    void Move(KeyCode key, float xMove, float yMove)
    {
        if(Input.GetKey(key))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(xMove, yMove, 0);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Finish")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
