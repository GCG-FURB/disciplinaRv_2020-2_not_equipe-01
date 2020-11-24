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
    public static Criatura Jogador;
    public GameObject Canvas;
    public static string Name;
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
            if (tb.TrackableName == "Inimigo1" || tb.TrackableName == "inimigo2" || tb.TrackableName == "inimigo3")
            {
                Canvas.SetActive(true);
                Name = tb.TrackableName;
            }
        }
    }
}