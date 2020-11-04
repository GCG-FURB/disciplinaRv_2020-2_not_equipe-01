using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criatura
{
    public int Ataque { get; set; }
    public int Defesa { get; set; }
    public int Esquiva { get; set; }
    public int Vida { get; set; }
    public int MaximaVida { get; set; }
    public string Nome { get; set; }
    public Dificuldades Dificuldade { get; set; }
    public bool Defendendo { get; set; }
    public string TrackerName { get; set; }
    public int SkillPoints { get; set; }
}

