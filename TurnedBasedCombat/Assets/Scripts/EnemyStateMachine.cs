using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private BattleStateMachine BSM;

    public BaseEnemy enemy;

    public enum TurnState
    {
        WAITING,
        CHOOSEACTION,
        PROCESSING,
        ACTION,
        DEAD
    }

    public TurnState currentState;

    //Bar Progression Variables
    private float curCooldown = 0f;
    private float maxCooldown = 5f;

    //For animation
    private Vector3 startPos;

    void Start()
    {
        currentState = TurnState.PROCESSING;
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case TurnState.WAITING:

                break;

            case TurnState.CHOOSEACTION:
                ChooseAction();
                currentState = TurnState.WAITING;
                break;

            case TurnState.PROCESSING:
                UpgradeProgressionBar();
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

        if (curCooldown >= maxCooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }
    }

    void ChooseAction()
    {
        TurnsHandler myTurn = new TurnsHandler();

        myTurn.Attacker = enemy.name;
        myTurn.AttackerGO = this.gameObject;
        myTurn.Attack_Target = BattleStateMachine.Instance.HeroesInBattle[Random.Range(0, BattleStateMachine.Instance.HeroesInBattle.Count)];
        BSM.CollectTurns(myTurn);
    }
}
