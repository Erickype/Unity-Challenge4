using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private float baseSpeed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        spawn = GameObject.Find("Spawn Manager");
        var sp = spawn.GetComponent<SpawnManagerX>();
        speed = sp.baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

    public void SetBaseSpeed(float baseSpeed)
    {
        this.baseSpeed = baseSpeed;
    }

}
