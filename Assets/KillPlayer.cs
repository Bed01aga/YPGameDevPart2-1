using UnityEngine;

public class KillPlayer : ButtonControllerESC
{
    public static bool PlayerIsDead;
    
    [SerializeField] private AudioSource audioSourcePlayer;
    [SerializeField] private AudioClip audioClipPlayer;
    [SerializeField] private AudioSource audioSourceGhost;
    [SerializeField] private AudioClip audioClipGhost;

    void Start()
    {
        PlayerIsDead = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerIsDead = true;
            audioSourcePlayer.PlayOneShot(audioClipPlayer);
            DeadMenu();
        }
        else if (collision.gameObject.CompareTag("Ghost"))
        {
            PlayerIsDead = true;
            audioSourceGhost.PlayOneShot(audioClipGhost);
            DeadMenu();

        }
    }


}
