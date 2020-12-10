using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class Init : MonoBehaviour
{
    public GameObject Canvas;
    public static string Name;
    public static int qtdPocoes;
    public static int qtdPocoesForca = 0;
    public static int qtdPocoesDefesa = 0;
    public static List<int> pocoes;
    public static List<int> pocoesForca;
    public static List<int> pocoesDefesa;
    public Text log;
    // Start is called before the first frame update
    void Start()
    {
        Inimigos.InicializarInimigos();
        qtdPocoes = 0;
        pocoes = new List<int>();
        pocoesForca = new List<int>();
        pocoesDefesa = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {

        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

        foreach (TrackableBehaviour tb in tbs)
        {
            if (tb.TrackableName == "Inimigo1" || tb.TrackableName == "inimigo2" || tb.TrackableName == "inimigo3")
            {
                Canvas.SetActive(true);
                Name = tb.TrackableName;
            }
        }
    }

    public void AumentarPocoes(int numero)
    {
        if (!pocoes.Contains(numero))
        {
            qtdPocoes++;
            log.text = "+1 Poção!";
            pocoes.Add(numero);
        }
        else
        {
            
            log.text = "Não há mais poções nesse lugar :(";
        }

        var coroutine = CleanText();
        StartCoroutine(coroutine);
    }

    public void AumentarPocoesForca(int numero)
    {
        if (!pocoesForca.Contains(numero))
        {
            qtdPocoesForca++;
            log.text = "Poção consumida! Seu ataque aumentou!";
            pocoesForca.Add(numero);
        }
        else
        {
            log.text = "Não há mais poções nesse lugar :(";
        }
        var coroutine = CleanText();
        StartCoroutine(coroutine);
    } 
    public void AumentarPocoesDefesa(int numero)
    {
        if (!pocoesDefesa.Contains(numero))
        {
            qtdPocoesDefesa++;
            log.text = "Poção consumida! Sua defesa aumentou!";
            pocoesDefesa.Add(numero);
        }
        else
        {
            log.text = "Não há mais poções nesse lugar :(";
        }
        var coroutine = CleanText();
        StartCoroutine(coroutine);
    }
    private IEnumerator CleanText()
    {
        yield return new WaitForSeconds(4);
        log.text = "";
    }
}