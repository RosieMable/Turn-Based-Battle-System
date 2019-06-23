using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour
{


    public BaseHero hero;

    public enum TurnState
    {
        WAITING,
        ADDTOLIST,
        PROCESSING,
        SELECTING,
        ACTION,
        DEAD
    }

    public TurnState currentState;

    //Bar Progression Variables
    private float curCooldown = 0f;
    private float maxCooldown = 5f;

    public Image progressBar;


    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnState.PROCESSING;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case TurnState.WAITING:

                break;

            case TurnState.ADDTOLIST:

                break;

            case TurnState.PROCESSING:
                UpgradeProgressionBar();
                break;

            case TurnState.SELECTING:

                break;

            case TurnState.ACTION:

                break;

            case TurnState.DEAD:

                break;
        }

    }

    void UpgradeProgressionBar()
    {
        curCooldown = curCooldown + Time.deltaTime;
        float calc_cooldown = curCooldown / maxCooldown;
        progressBar.transform.localScale = new Vector3(Mathf.Clamp(calc_cooldown, 0, 1),
                                                       progressBar.transform.localScale.y, 
                                                       progressBar.transform.localScale.z);

        if (curCooldown >= maxCooldown)
        {
            currentState = TurnState.ADDTOLIST;
        }
    }

}
