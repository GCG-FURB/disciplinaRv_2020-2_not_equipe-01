using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Init : MonoBehaviour
{
    public static Criatura Jogador;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

        foreach (TrackableBehaviour tb in tbs)
        {
            if (Inimigos.RetornarListaInimigos().Contains(tb.TrackableName))
            {
                Batalha.Inimigo = Inimigos.Criaturas.First(p => p.TrackerName == tb.TrackableName);
                Batalha.Jogador = Jogador;
                Utils.ChangeScene(ScenesNames.Batalha);
            }
        }
    }
}