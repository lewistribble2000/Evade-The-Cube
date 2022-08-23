using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Stats stats;
    public HUDController hudController;

    public Transform leftWall;
    public Transform rightWall;

    private void Update()
    {
        if(stats.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalPosition = transform.position.x + horizontalInput * stats.speed * Time.deltaTime;

        float playerSize = transform.localScale.x / 2;
        float leftWallSize = leftWall.localScale.x / 2;
        float rightWallSize = rightWall.localScale.x / 2;

        if (horizontalPosition - playerSize <= leftWall.position.x + leftWallSize || horizontalPosition + playerSize >= rightWall.position.x - rightWallSize)
        {
            return; 
        }

        transform.position = new Vector3(
            horizontalPosition,
            1,
            transform.position.z);
    }

    public void recieveDamage()
    {
        stats.UpdateHealth(10);
        hudController.UpdateHealthText(stats.health.ToString());
    }
}
