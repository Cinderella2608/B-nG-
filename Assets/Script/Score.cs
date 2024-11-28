using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public Text missText;
    public Text gameOverText; //thông báo hết game
    private bool GameOver = false;
    private bool GamePause = false;

    private int Win = 10;
    private int Lose = 10;

    private int score = 0;
    private int miss = 0;

    public string nextSceneName = "Scene2";  // Tên cảnh tiếp theo
    public string currentSceneName = "Scene1";  // Tên cảnh hiện tại

    private void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }
    public void AddScore(int points)
    {
        if (GameOver) return;
        score += points;
        CheckWin();
        UpdateScoreDisplay();
    }
    public void AddMissScore(int points)
    {
        if (GameOver) return;
        miss += points;  // Cộng điểm miss
        CheckLose();
        UpdateMissDisplay();  // Cập nhật điểm miss hiển thị
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString() + " / 10";
    }
    private void UpdateMissDisplay()
    {
        missText.text = "Miss: " + miss.ToString() + " / 10";
    }

    void CheckWin()
    {
        if(score >= Win && !GameOver)
        {
            GameOver = true;
            gameOverText.text = "Thắng, bấm sang màn";
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0; // dừng game
            StartCoroutine(Chobamnut(true));
            //SceneManager.LoadScene("Scene2");
        }
    }
    void CheckLose()
    {
        if (miss >= Lose && !GameOver)
        {
            GameOver = true;
            gameOverText.text = "Thua, chờ tý 2 giây...";
            gameOverText.gameObject.SetActive(true);
            StartCoroutine(Restart(2f));
            //SceneManager.LoadScene("Scene1");
        }
    }
    IEnumerator Chobamnut(bool win)
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        if (win)
        {
            Time.timeScale = 1; // bắt đầu game
            SceneManager.LoadScene("Scene2");
        }
    }
    IEnumerator Restart(float time)
    {
        yield return new WaitForSeconds(time);
        Time.timeScale = 1; // bắt đầu game
        SceneManager.LoadScene("Scene1");
    }
}
