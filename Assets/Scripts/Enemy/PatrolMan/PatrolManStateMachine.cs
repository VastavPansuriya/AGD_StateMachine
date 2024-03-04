using StatePattern.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern.Enemy
{
    public class PatrolManStateMachine : GenericStateMachine<PatrolManController>
    {
        private PatrolManController Owner;
        private IState currentState;

        public PatrolManStateMachine(PatrolManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }

        private void CreateStates()
        {
            allStates.Add(States.IDLE, new IdleState<PatrolManController>(this));
            allStates.Add(States.PATROLLING, new PatrollingState<PatrolManController>(this));
            allStates.Add(States.CHASING, new ChasingState<PatrolManController>(this));
            allStates.Add(States.SHOOTING, new ShootingState<PatrolManController>(this));
        }

    }
}