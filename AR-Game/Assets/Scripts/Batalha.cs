using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Batalha : MonoBehaviour
{
    public static Criatura Inimigo;
    public Criatura Jogador;
    public GameObject Golem;
    public GameObject Dragao;
    public static string Name;
    public Text Hp;
    public Text Sp;
    public Text PlayerLog;
    public Text EnemyLog;
    // Start is called before the first frame update
    void Start()
    {
        Name = Init.Name;
        Inimigo = Inimigos.Criaturas.First(p => p.TrackerName == Name);
        Jogador = new Criatura()
        {
            Ataque = 70,
            Defesa = 45,
            Esquiva = 10,
            Vida = 200,
            SkillPoints = 0,
            MaximaVida = 200
            
        };
    }
    // Update is called once per frame
    void Update()
    {
        
        if(PlayerLog.text == "Você tenta fugir! \nVocê consegue fugir!" || 
            PlayerLog.text == "O Inimigo foi derrotado! \nRetornando para tela de seleção de inimigos"||
            EnemyLog.text == "Você foi derrotado! \nRetornando para a tela de seleção de inimigos")
        {
            var coroutine = ChangeScene();
            StartCoroutine(coroutine);
        }
            

        if (Name == "Inimigo1")
            Golem.SetActive(true);
        
        if (Name == "inimigo2")
            Dragao.SetActive(true);

        Hp.text = Convert.ToString(Jogador.Vida);
        Sp.text = Convert.ToString(Jogador.SkillPoints);
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        Utils.ChangeScene(ScenesNames.Inicio);
    }

    private void Atacar(Criatura atacante, Criatura defensora, bool player)
    {
        var txt = "";
        var random = new System.Random();
        var dano = atacante.Ataque - defensora.Defesa;
        if (player)
            dano += 20 * Init.qtdPocoesForca;
        else
            dano -= 20 * Init.qtdPocoesDefesa;

        dano = dano < 0 ? 0 : dano;
        dano = defensora.Defendendo ? dano / 2 : dano;
        dano = Convert.ToInt32(dano * Convert.ToDouble(random.Next(60, 150)) / 100);
        if (atacante.SkillPoints >= 100)
        {
            dano *= 2;
            if (player)
                txt = "Você usou uma técnica especial no ";
            else
                txt = $"{atacante.Nome} usou uma técnica especial e causou {dano} de dano";
            atacante.SkillPoints = 0;
        }
        else
        {
            if (player)
                txt = "Você atacou o ";
            else
                txt = $"{atacante.Nome} atacou e causou {dano} de dano \n";

            atacante.SkillPoints += random.Next(1, 10);
        }
        if (player)
        {
            PlayerLog.text += $"{txt}{defensora.Nome} e causou {dano} de dano \n";
            PlayerLog.color = Color.blue;
        }
        else
        {
            EnemyLog.text += txt;
            EnemyLog.color = Color.red;
        }
        

        var chanceDeEsquiva = defensora.Esquiva;
        defensora.SkillPoints += random.Next(1, 35);
        if (chanceDeEsquiva <= random.Next(1, 100))
            defensora.Vida -= dano;
    }
    public void RecuperarVida()
    {
        if(Init.qtdPocoes > 0)
        {
            Jogador.Vida = Jogador.MaximaVida;
            Init.qtdPocoes--;
            PlayerLog.text = "Vida Recuperada!";
        }
        else
        {
            PlayerLog.text = "Você não possui poções para recuperar vida";
        }
        
    }

    public void AtacarJogador()
    {
        PlayerLog.text = "";
        EnemyLog.text = "";
        Atacar(Jogador, Inimigo, true);
        if(Inimigo.Vida <= 0)
        {
            EnemyLog.text = "";
            PlayerLog.text = "O Inimigo foi derrotado! \nRetornando para tela de seleção de inimigos";
            Inimigo.Vida = Inimigo.MaximaVida;
        }
        Atacar(Inimigo, Jogador, false);
        if(Jogador.Vida <= 0)
        {
            PlayerLog.text = "";
            EnemyLog.text = "Você foi derrotado! \nRetornando para a tela de seleção de inimigos";
        }
    }

    private IEnumerator CleanText()
    {
        yield return new WaitForSeconds(4);
        PlayerLog.text = "";
        EnemyLog.text = "";
    }

    public void Defender()
    {
        Jogador.Defendendo = true;
        EnemyLog.text = "";
        PlayerLog.text = "Você está defendendo\n";
        PlayerLog.color = Color.blue;
        Atacar(Inimigo, Jogador, false);
        if (Jogador.Vida <= 0)
        {
            PlayerLog.text = "";
            EnemyLog.text = "Você foi derrotado! \n Retornando para a tela de seleção de inimigos";
        }
    }

    public void Fugir()
    {
        var random = new System.Random().Next(1, 100);
        if (40 <= random)
        {
            PlayerLog.text = "Você tenta fugir! \nVocê consegue fugir!";
            PlayerLog.color = Color.blue;
            var coroutine = CleanText();
            StartCoroutine(coroutine);
        }
        else
        {
            PlayerLog.text = "Você tenta fugir! \nVocê não consegue fugir!";
            PlayerLog.color = Color.red;
        }
            
    }

   
}
