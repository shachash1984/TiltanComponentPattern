using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static public GameManager S;
    public int score;
    public Text scoreText;
    public List<Enemy> enemiesInLevel;
    public delegate void GameEvent(bool on);
    public static event GameEvent GameEventOccured;
    

    private void Awake()
    {
        if (S != null)
            Destroy(gameObject);
        S = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //if (S != this)
        //    Destroy(gameObject);
        //S = this;
        enemiesInLevel = new List<Enemy>(FindObjectsOfType<Enemy>());
        Kobi k = FindObjectOfType<Kobi>();
        Rigidbody r = k.GetComponent<Rigidbody>();
        if (r.constraints == RigidbodyConstraints.None)
            k.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation & RigidbodyConstraints.FreezePositionZ;
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (!scoreText) 
            scoreText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        scoreText.text = string.Format("Score: {0}", score);
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelSequence());
    }

    IEnumerator NextLevelSequence()
    {
        yield return new WaitForSeconds(2f);
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RemoveEnemy(Enemy e)
    {
        enemiesInLevel.Remove(e);
    }

    public bool KilledAllEnemies()
    {
        return enemiesInLevel.Count == 0;
    }

    public void PlayerChangedState(bool isDead)
    {
        if (GameEventOccured != null)
            GameEventOccured(isDead);
    }
}
