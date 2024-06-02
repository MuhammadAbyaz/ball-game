using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_gameOverText;
    [SerializeField] TextMeshProUGUI m_timerText;
    [SerializeField] Score m_playerScore;
    [SerializeField] Score m_opponentScore;
    [SerializeField] float m_gameTimeInSeconds = 60f;
    float m_timer;
    bool m_gamePlaying = false;
    public static float RespawnHeight = 0.25f;

    void Start(){
        Time.timeScale = 0f;
        m_timer = m_gameTimeInSeconds;
        UpdateTimer();
    }
    void UpdateTimer(){
        m_timerText.text = string.Format("{0:0}:{1:00}",Mathf.Floor(m_timer/60),Mathf.Floor(m_timer % 60));
    }
    void FixedUpdate(){
        if (!m_gamePlaying) return;
        m_timer -= Time.fixedDeltaTime;
        UpdateTimer();

        if(m_timer <= 0){
            GameOver();
            m_timer = 0;
        }
    }
    void GameOver(){
        m_gamePlaying = false;
        Time.timeScale = 0f;

        string gameOverText;
        if(m_playerScore.ScoreValue > m_opponentScore.ScoreValue){
            gameOverText = "You Win!!";
        }
        else if (m_playerScore.ScoreValue < m_opponentScore.ScoreValue){
            gameOverText = "You lose!!";
        }
        else{
            gameOverText = "Tie!!";
        }
        m_gameOverText.text = gameOverText + "\n\nPress Space to Restart";
        m_gameOverText.gameObject.SetActive(true);
    }
    public void RestartGame(){
        if (!m_gamePlaying){
            Time.timeScale = 1f;
            m_gameOverText.gameObject.SetActive(false);
            m_timer = m_gameTimeInSeconds;
            m_gamePlaying = true;
        }
    }
}
