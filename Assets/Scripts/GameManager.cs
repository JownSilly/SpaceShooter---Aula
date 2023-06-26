using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private bool isGameOver = false;
    [SerializeField]
    private GameObject gameActive;
    [SerializeField]
    private GameObject menu;
    [Header("Naves-Selecao")]
    [SerializeField]
    private GameObject[] navesPrefabs;
    [SerializeField]
    private Transform _initialPosition;
    [Header("GameScore")]
    private int scoreActual;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        gameActive.SetActive(false);
        menu.SetActive(true);
        scoreText.SetText("Score: {0:0000000}", scoreActual);
    }
    private void Update()
    {
        if (isGameOver)
        {
            Restart();
        }
    }
    public void ShipSelected(int indexChoose)
    {
        menu.SetActive(false);
        Instantiate (navesPrefabs[indexChoose], _initialPosition.position, _initialPosition.rotation);
        gameActive.SetActive(true);
        
        
    }
    //Player Gerenciamento
    public void PlayerDied()
    {
        isGameOver = true;
    }
    public void LivesUpdate(int lives)
    {
        Debug.Log(lives);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        isGameOver = false;
    }
    public void ScoreUpdate(int score)
    {
        scoreActual += score;
        scoreText.SetText("Score: {0:0000000}", scoreActual);
    }
}
