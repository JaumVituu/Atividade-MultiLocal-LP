using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas menuPrincipal;
    public Canvas selecaoTela;


    public void SelecionarTela(){
        menuPrincipal.gameObject.SetActive(false);
        selecaoTela.gameObject.SetActive(true);
    }

    public void AtivarElemento(){
        menuPrincipal.gameObject.SetActive(true);
        selecaoTela.gameObject.SetActive(false);
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
}
