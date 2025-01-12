using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private string enemyTag = "Enemy";
    public static bool isGamepaused = false;
    [SerializeField] GameObject text;
    
    //public GameObject pauseMenu;
    private void Awake()
    {
        if (LevelManager.instance == null) instance = this;
        
        
       
    }

    public void GameOver()
    {

        UIManager ui = FindObjectOfType<UIManager>();
        if (ui != null)
        {
            ui.DeathScene();
        }
        else
        {
            Debug.LogError("UIManager not found!");
        }
    }


  
    void OnTriggerEnter2D(Collider2D other)
    {
        int counter = CountEnemies();
        if (other.tag == "Player" && counter == 0)
            Invoke("ReloadScene", 1f);
        else if (other.tag == "Player" && counter > 0)
            StartCoroutine("KillAll");

    }
    void ReloadScene()
    {
        SceneManager.LoadScene("Level2");


    }

    

    public int CountEnemies()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag(enemyTag).Length);
        return GameObject.FindGameObjectsWithTag(enemyTag).Length;
    }

    public IEnumerator KillAll()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        text.SetActive(false);
        
    }
}
