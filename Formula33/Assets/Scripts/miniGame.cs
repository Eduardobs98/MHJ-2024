using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGame : MonoBehaviour
{
    public int type;
    public miniGameController controlador;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Finished()
    {
        controlador.EndMinigame();
    }
}
