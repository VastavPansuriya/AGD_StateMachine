using StatePattern.StateMachine;
using System.Collections.Generic;

namespace StatePattern.Enemy
{
    public class OnePunchManStateMachine :  GenericStateMachine<OnePunchManController>
    {
        public OnePunchManStateMachine(OnePunchManController Owner) : base(Owner)
        {
            this.Owner = Owner;
            CreateStates();
            SetOwner();
        }
        private void CreateStates()
        {
            allStates.Add(States.IDLE, new IdleState<OnePunchManController>(this));
            allStates.Add(States.ROTATING, new RotatingState<OnePunchManController>(this));
            allStates.Add(States.SHOOTING, new ShootingState<OnePunchManController>(this));
        }
    }
}