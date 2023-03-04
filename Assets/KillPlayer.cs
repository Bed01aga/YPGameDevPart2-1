using UnityEngine;

public class KillPlayer : ButtonControllerESC
{
    public static bool PlayerIsDead;

    void Start()
    {
        PlayerIsDead = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ghost"))
        {
            PlayerIsDead = true;
            DeadMenu();
        }
    }


}
