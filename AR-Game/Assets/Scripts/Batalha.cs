using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Batalha : MonoBehaviour
{
    public static Criatura Inimigo;
    public static Criatura Jogador;
    public GameObject Golem;
    public GameObject Dragao;
    public static string Name;
    // Start is called before the first frame update
    void Start()
    {
        Name = Init.Name;
        Inimigo = Inimigos.Criaturas.First(p => p.TrackerName == Name);
        Jogador = Init.Jogador;

    }

    // Update is called once per frame
    void Update()
    {
        if (Name == "Inimigo1")
            Golem.SetActive(true);
        
        if (Name == "inimigo2")
            Dragao.SetActive(true);
        

    }
    private static void Atacar(Criatura atacante, Criatura defensora)
    {
        var random = new System.Random();
        var dano = atacante.Ataque - defensora.Defesa;
        dano = dano < 0 ? 0 : dano;
        dano = defensora.Defendendo ? dano / 2 : dano;
        if (atacante.SkillPoints >= 100)
            dano *= 2;
        else
            atacante.SkillPoints += random.Next(1, 10);

        var chanceDeEsquiva = defensora.Esquiva;
        defensora.SkillPoints += random.Next(1, 35);
        if (chanceDeEsquiva <= random.Next(1, 100))
            defensora.Vida -= dano;
    }

    public static void AtacarJogador()
    {
        Atacar(Jogador, Inimigo);
        Atacar(Inimigo, Jogador);
    }

    public static void Defender()
    {
        Jogador.Defendendo = true;
        Atacar(Inimigo, Jogador);
    }

    public static void Fugir()
    {
        var random = new System.Random().Next(1, 100);

        if (40 <= random)
            Utils.ChangeScene(ScenesNames.Inicio);
    }

   
}
