using StatePattern.Enemy;
using StatePattern.Player;
using StatePattern.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManController : EnemyController
{
    private CloneManStateMachine stateMachine;
    public int CloneCountLeft { get; private set; }
    public CloneManController(EnemyScriptableObject enemyScriptableObject, int cloneCountLeft) : base(enemyScriptableObject)
    {
        SetCloneCount(enemyScriptableObject.CloneCount);
        enemyView.SetController(this);
        SetColor(EnemyColorData.Default);
        CreateStateMachine();
        stateMachine.ChangeState(States.IDLE);
        CloneCountLeft = cloneCountLeft;
    }
    public void SetColor(EnemyColorData enemyColorData)
    {
        enemyView.SetColor(enemyColorData);
    }

    public void SetCloneCount(int cloneCountToSet) => CloneCountLeft = cloneCountToSet;

    private void CreateStateMachine() => stateMachine = new CloneManStateMachine(this);    

    public override void UpdateEnemy()
    {
        if (currentState == EnemyState.DEACTIVE)
            return;

        stateMachine.Update();
    }

    public override void PlayerEnteredRange(PlayerController targetToSet)
    {
        base.PlayerEnteredRange(targetToSet);
        stateMachine.ChangeState(States.CHASING);
    }

    public override void PlayerExitedRange() => stateMachine.ChangeState(States.IDLE);

    public override void Die()
    {
        if (CloneCountLeft > 0)
            stateMachine.ChangeState(States.CLONING);
        base.Die();
    }

    public void Teleport() => stateMachine.ChangeState(States.TELEPORTING);

}