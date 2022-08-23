using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchController : MonoBehaviour
{
    public Stats stats;

    private PlayerController playerController;

    private float destroyPosZ = -14f;

    private void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, playerController.transform.position) <= 1f)
        {
            Destroy(gameObject);
        } else if(transform.position.z <= destroyPosZ)
        {
            Destroy(gameObject);
            playerController.recieveDamage();
        }

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - stats.speed * Time.deltaTime);
    }
}
