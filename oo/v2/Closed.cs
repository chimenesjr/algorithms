using System;

namespace algorithms.oov2
{
    class Closed : IAccountState
    {
        public IAccountState Close() => this;
        public IAccountState Deposit() => this;

        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HoldVerified() => this;

        public IAccountState Withdraw() => this;

        public IAccountState Withdraw(Action subtractToBalance) => this;
    }
}