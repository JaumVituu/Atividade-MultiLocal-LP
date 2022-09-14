using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public float currentTime;
    public int score;
    public bool isGameOver;
    public Text timeText;
    public Text teamScore;
    public Text gameOverText;
    public Button playAgainButton;
    public Button goToMenuButton;
    public Text b_Catapult;
    public Text v_Catapult;
    public new AudioSource audio;
    
    bool isEnd;
    void Start()
    {
        currentTime = 0f;
        isGameOver = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //PlayerPrefs.DeleteKey("Time Record");
        //PlayerPrefs.DeleteKey("Score Record");
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Night"){
            if(currentTime > PlayerPrefs.GetFloat("Night Time Record",0)){
                timeText.text = ("Time: " + FormatTime(currentTime) + " \r\nNEW RECORD!");
                timeText.color = Color.yellow;
            }

            if(score > PlayerPrefs.GetInt("Night Score Record", 0)){
                teamScore.text = "Score: " + score + " \r\nNEW RECORD!";
                teamScore.color = Color.yellow;
            }

            if(isGameOver == false){
                currentTime += Time.deltaTime;
                timeText.text = ("Time: " + FormatTime(currentTime));
                teamScore.text = "Score: "+ score;
            }
            else{
                if(currentTime > PlayerPrefs.GetFloat("Night Time Record",0)){
                    PlayerPrefs.SetFloat("Night Time Record", currentTime);
                }
                if(score > PlayerPrefs.GetInt("Night Score Record", 0)){
                    PlayerPrefs.SetInt("Night Score Record", score);
                }

                StartCoroutine(MostrarGameOver());
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        
                              
        }

        else{
            if(currentTime > PlayerPrefs.GetFloat("Time Record",0)){
                timeText.text = ("Time: " + FormatTime(currentTime) + " \r\nNEW RECORD!");
                timeText.color = Color.yellow;
            }

            if(score > PlayerPrefs.GetInt("Score Record", 0)){
                teamScore.text = "Score: " + score + " \r\nNEW RECORD!";
                teamScore.color = Color.yellow;
            }

            if(isGameOver == false){
                currentTime += Time.deltaTime;
                timeText.text = ("Time: " + FormatTime(currentTime));
                teamScore.text = "Score: "+ score;
            }
            else{
                if(currentTime > PlayerPrefs.GetFloat("Time Record",0)){
                    PlayerPrefs.SetFloat("Time Record", currentTime);
                }
                if(score > PlayerPrefs.GetInt("Score Record", 0)){
                    PlayerPrefs.SetInt("Score Record", score);
                }
                
                StartCoroutine(MostrarGameOver());
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
            }
        }
    }

    public string FormatTime( float time ){
        int minutes = (int) time / 60 ;
        int seconds = (int) time%60;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator MostrarGameOver(){
        audio.Play();
        yield return new WaitForSeconds(2);
        //Debug.Log("Mostra texto");
        gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        playAgainButton.gameObject.SetActive(true);
        goToMenuButton.gameObject.SetActive(true);
    }

    public void ReiniciarFase(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrMenu(){
        SceneManager.LoadScene("Menu");
    }
}
