using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public InputController inputController { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        inputController = GetComponentInChildren<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
