using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas menuPrincipal;
    public Canvas selecaoTela;
    public Canvas creditoTela;
    public Canvas recordeTela;
    public GameObject VandalPreview;
    public GameObject BerserkerPreview;
    public Text record;


    public void SelecionarTela(){
        menuPrincipal.gameObject.SetActive(false);
        selecaoTela.gameObject.SetActive(true);
    }

    public void VoltarParaMenu(){
        menuPrincipal.gameObject.SetActive(true);
        selecaoTela.gameObject.SetActive(false);
        VandalPreview.gameObject.SetActive(true);
        BerserkerPreview.gameObject.SetActive(true);
        VandalPreview.gameObject.SetActive(true);
        creditoTela.gameObject.SetActive(false);
        recordeTela.gameObject.SetActive(false);
    } 

    public void AtivarCredito(){
        creditoTela.gameObject.SetActive(true);
        menuPrincipal.gameObject.SetActive(false);
        VandalPreview.gameObject.SetActive(false);
    }

    public void MostrarRecordes(){
        BerserkerPreview.gameObject.SetActive(false);
        menuPrincipal.gameObject.SetActive(false);
        recordeTela.gameObject.SetActive(true);
        AtualizarRecordes();

    }

    public void JogarDia(){
        SceneManager.LoadScene("Day");
    }

    public void JogarNoite(){
        SceneManager.LoadScene("Night");
    }

    public void SairDoJogo(){
        Application.Quit();
    }

    public void AtualizarRecordes(){
        record.text = "Time record: " + FormatString(PlayerPrefs.GetFloat("Time Record", 0)) + "\r\nScore record: " + PlayerPrefs.GetInt("Score Record", 0) + "\r\n\r\n NIGHT MODE Time record: " + FormatString(PlayerPrefs.GetFloat("Night Time Record", 0)) + "\r\n NIGHT MODE Score record: " + PlayerPrefs.GetInt("Night Score Record", 0);
    }

    public string FormatString(float time){
        int minutes = (int)time/60;
        int seconds = (int)time%60;
        return string.Format("{0:00}:{1:00}",minutes,seconds);
    }

    public void LimparRecorde(){
        PlayerPrefs.DeleteAll();
        record.text = "Time record: " + FormatString(PlayerPrefs.GetFloat("Time Record", 0)) + "\r\nScore record: " + PlayerPrefs.GetInt("Score Record", 0) + "\r\n\r\n NIGHT MODE Time record: " + FormatString(PlayerPrefs.GetFloat("Night Time Record", 0)) + "\r\n NIGHT MODE Score record: " + PlayerPrefs.GetInt("Night Score Record", 0);
    }
}
