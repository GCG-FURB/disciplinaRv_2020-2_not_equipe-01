using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos
{
    public static List<Criatura> Criaturas { get; private set; }
    public static List<string> RetornarListaInimigos()
    {
        var lista = new List<string>()
        {
            "Inimigo1",
            "Inimigo2",
            "Inimigo3"
        };

        return lista;
    }
    
    public static void InicializarInimigos()
    {
        if (Criaturas == null)
            Criaturas = new List<Criatura>();

        Criaturas.Add(new Criatura()
        {
            Ataque = 80,
            Defesa = 50,
            Esquiva = 5,
            Vida = 100,
            MaximaVida = 100,
            Nome = "Golem",
            Dificuldade = Dificuldades.Facil,
            TrackerName = "Inimigo1"
        });

        Criaturas.Add(new Criatura()
        {
            Ataque = 120,
            Defesa = 60,
            Esquiva = 15,
            Vida = 200,
            Nome = "Haroldo",
            Dificuldade = Dificuldades.Medio
        });

        Criaturas.Add(new Criatura()
        {
            Ataque = 200,
            Defesa = 80,
            Esquiva = 40,
            Vida = 200,
            MaximaVida = 200,
            Nome = "Dragão",
            Dificuldade = Dificuldades.Dificil,
            TrackerName = "inimigo2"
        }) ;

        Criaturas.Add(new Criatura()
        {
            Ataque = 3000,
            Defesa = 400,
            Esquiva = 99,
            Vida = 1000,
            Nome = "Garcia",
            Dificuldade = Dificuldades.SeCairNesseNivelDesiste
        });

        Criaturas.Add(new Criatura()
        {
            Ataque = 300,
            Defesa = 90,
            Esquiva = 50,
            Vida = 400,
            Nome = "Reginaldo",
            Dificuldade = Dificuldades.Impossivel,
            TrackerName = "inimigo3"
        });
    }
}
