using System;

namespace algorithms.oov2
{
    class Frozen : IAccountState
    {
        private Action OnUnfreeze {get;}

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IAccountState Deposit(Action addToBalance)
        {
            OnUnfreeze();
            addToBalance();
            return new Active(OnUnfreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState Withdraw(Action subtractToBalance)
        {
            OnUnfreeze();
            subtractToBalance();
            return new Active(OnUnfreeze);
        }

        public IAccountState HoldVerified() => this;

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}