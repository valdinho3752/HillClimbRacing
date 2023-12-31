using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [SerializeField] private GameObject gameOverCanvas;

    private void Awake() {
        if(instancia == null){
            instancia = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver(){
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
