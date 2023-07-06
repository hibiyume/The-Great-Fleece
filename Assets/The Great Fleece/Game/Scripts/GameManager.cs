using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null!");
            }

            return _instance;
        }
    }
    
    [SerializeField] private PlayableDirector introCutscene;
    public bool HasCard { get; set; }
    
    private bool _introIsSkipped;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_introIsSkipped) //intro cutscene skip
        {
            _introIsSkipped = true;
            introCutscene.time = 53.7f;
        }
    }

    public void GameOver()
    {
        AudioManager.Instance.StopAudio();
    }

    public void GameWon()
    {
        AudioManager.Instance.StopAudio();
    }
}