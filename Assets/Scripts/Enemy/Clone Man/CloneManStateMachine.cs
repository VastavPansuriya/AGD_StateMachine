using StatePattern.Enemy;
using StatePattern.StateMachine;
using UnityEngine.Analytics;

internal class CloneManStateMachine : GenericStateMachine<CloneManController>
{
    private CloneManController cloneManController;

    public CloneManStateMachine(CloneManController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        States.Add(StatePattern.StateMachine.States.IDLE, new IdleState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.PATROLLING, new PatrollingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.CHASING, new ChasingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.SHOOTING, new ShootingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.TELEPORTING, new TeleportingState<CloneManController>(this));
        States.Add(StatePattern.StateMachine.States.CLONING, new CloningState<CloneManController>(this));
    }
}