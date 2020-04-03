using System;

namespace algorithms.oov2
{
    class NotVerified : IAccountState
    {
        private Action OnUnfreeze {get;}

        public NotVerified(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public IAccountState Close() => new Closed();
        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HoldVerified() => new Active(OnUnfreeze);

        public IAccountState Withdraw(Action subtractToBalance) => this;
    }
}