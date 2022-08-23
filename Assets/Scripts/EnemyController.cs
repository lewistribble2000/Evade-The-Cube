using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Stats stats;
    private float destroyPosZ = -14f;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if(Vector3.Distance(playerController.transform.position, transform.position) < 1.0f)
        {
            Destroy(gameObject);
            playerController.recieveDamage();
        } else if(transform.position.z <= destroyPosZ)
        {
            Destroy(gameObject);
        }

        transform.position = new Vector3(
            transform.position.x, 
            0.5f,
            transform.position.z - stats.speed * Time.deltaTime);
    }
}
