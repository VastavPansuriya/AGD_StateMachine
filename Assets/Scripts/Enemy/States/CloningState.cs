﻿using StatePattern.Enemy;
using StatePattern.Main;
using StatePattern.Player;
using StatePattern.StateMachine;

internal class CloningState<T> : IState where T : EnemyController
{
    public EnemyController Owner { get; set; }
    private GenericStateMachine<T> stateMachine;

    public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

    public void OnStateEnter()
    {
        CreateAClone();
        CreateAClone();
    }

    public void Update() { }

    public void OnStateExit() { }

    private void CreateAClone()
    {
        CloneManController clonedRobot = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as CloneManController;
        clonedRobot.SetCloneCount((Owner as CloneManController).CloneCountLeft - 1);
        clonedRobot.Teleport();
        clonedRobot.SetColor(EnemyColorData.Highlight);
        GameService.Instance.EnemyService.AddEnemy(clonedRobot);
    }
}