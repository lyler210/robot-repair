using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public PlayerController player;
    EnemyController[] enemies;
    public UIHandler uiHandler;
    int enemiesFixed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = FindObjectsByType<EnemyController>();
        foreach (var enemy in enemies)
        {
            enemy.OnFixed += HandleEnemyFixed;
        }
        uiHandler.SetCounter(0, enemies.Length);
        player.OnTalkedToNPC += HandlePlayerTalkedToNPC;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health <= 0)
        {
            uiHandler.DisplayLoseScreen();
            Invoke(nameof(ReloadScene), 3f);
        }

        //if (AllEnemiesFixed())
        //{
        //uiHandler.DisplayWinScreen();
        //Invoke(nameof(ReloadScene), 3f);
        //}
    }

    bool AllEnemiesFixed()
    {
        foreach (EnemyController enemy in enemies)
        {
            if (enemy.isBroken) return false;
        }
        return true;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void HandleEnemyFixed()
    {
        enemiesFixed++;
        uiHandler.SetCounter(enemiesFixed, enemies.Length);
    }
    
    void HandlePlayerTalkedToNPC()
    {        
        if (AllEnemiesFixed())
        {
            uiHandler.DisplayWinScreen();
            Invoke(nameof(ReloadScene), 3f);
        }
        else
        {
            UIHandler.instance.DisplayDialogue();
        }
    }
}
