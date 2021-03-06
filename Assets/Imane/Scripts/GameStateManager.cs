using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    public int currentScore;
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
                return null;
            return _instance;
        }
    }

    public bool isGameOver = false;
    public float timeScaleIncrease = 1f;
    private bool isReadyToRestart = false;

    public GameObject OnDisableGameOver;
    public GameObject OnDisableGameOverUI;
    public GameObject OnGameOver;
    public GameObject OnVictory;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Cursor.visible = false;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!AudioManager.Instance.stopAllAudios)
                AudioManager.Instance.PlayAudio("RainAmbient", Audio.AudioType.BACKGROUND, AudioManager.AudioAction.START);
        }

        else
        {
            if (EnemySpawnerManager.Instance.totalEnemies == 0)
            {
                StartCoroutine(Victory(true));
            }

            if (!AudioManager.Instance.stopAllAudios)
                AudioFirstLevel();

            if (isReadyToRestart)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public IEnumerator GameOver(bool value)
    {
        GetComponent<PauseMenu>().holdPauseMenu = true;
        isGameOver = true;
        Time.timeScale = 1f;

        yield return new WaitForSeconds(1f);

        OnDisableGameOver.SetActive(false);
        OnDisableGameOverUI.SetActive(false);
        OnGameOver.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);

        yield return new WaitUntil(() => Input.anyKeyDown);
  
        isReadyToRestart = true;
        isGameOver = false;
        GetComponent<PauseMenu>().holdPauseMenu = false;
    }

    public IEnumerator Victory(bool value)
    {
        GetComponent<PauseMenu>().holdPauseMenu = true;
        isGameOver = true;
        Time.timeScale = 1f;

        yield return new WaitForSeconds(1f);

        OnDisableGameOver.SetActive(false);
        OnDisableGameOverUI.SetActive(false);
        OnVictory.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);

        yield return new WaitUntil(() => Input.anyKeyDown);

        isReadyToRestart = true;
        isGameOver = false;
        GetComponent<PauseMenu>().holdPauseMenu = false;
    }

    public bool IsGameOver()
    {
        return (isGameOver);
    }

    public void AudioFirstLevel()
    {
        AudioManager.Instance.PlayAudio("Ambient", Audio.AudioType.BACKGROUND, AudioManager.AudioAction.START);
        AudioManager.Instance.PlayAudio("RainAmbient", Audio.AudioType.BACKGROUND, AudioManager.AudioAction.START);
    }

    public void OnStartGameOver()
    {
        StartCoroutine(GameOver(true));
    }
}
