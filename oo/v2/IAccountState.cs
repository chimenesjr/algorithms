using System;

namespace algorithms.oov2
{
    // it's the new state after the operation
    interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractToBalance);
        IAccountState Freeze();
        IAccountState HoldVerified();
        IAccountState Close();
    }
}