using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateMachine : Singleton<BattleStateMachine>
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
    }

    public PerformAction battleState;

    public List<TurnsHandler> PerformList = new List<TurnsHandler>();
    public List<GameObject> HeroesInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        battleState = PerformAction.WAIT;

        AddAllEnemies(EnemiesInBattle);
        AddAllHeroes(HeroesInBattle);

    }

    // Update is called once per frame
    void Update()
    {
        switch (battleState)
        {
            case PerformAction.WAIT:
                break;
            case PerformAction.TAKEACTION:
                break;
            case PerformAction.PERFORMACTION:
                break;
            default:
                break;
        }
    }


    public void AddAllEnemies(List<GameObject> list)
    {
        EnemyStateMachine[] enemies = FindObjectsOfType(typeof(EnemyStateMachine)) as EnemyStateMachine[];

        foreach (EnemyStateMachine enemy in enemies)
        {
            list.Add(enemy.gameObject);
        }
    }

    public void AddAllHeroes(List<GameObject> list)
    {
        HeroStateMachine[] enemies = FindObjectsOfType(typeof(HeroStateMachine)) as HeroStateMachine[];

        foreach (HeroStateMachine enemy in enemies)
        {
            list.Add(enemy.gameObject);
        }
    }

    public void CollectTurns(TurnsHandler input)
    {
        PerformList.Add(input);
    }
}
 