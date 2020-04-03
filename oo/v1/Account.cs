using System;

namespace algorithms.oov1
{
    public class Account
    {
        private bool IsVerified {get;set;}
        public bool IsClosed { get; set; }
        public decimal Balance { get; set; }
        public bool IsFrozen { get; private set; }

        private Action OnUnfreeze {get;}

        public Account(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }
        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;
            if(IsFrozen)
            {
                IsFrozen = false;
                OnUnfreeze();
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            if (IsFrozen)
            {
                IsFrozen = false;
                OnUnfreeze();
            }

            Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void CLose()
        {
            IsClosed = true;
        }

        public void Freeze()
        {
            if (IsClosed)
                return;
            if(!IsVerified)
                return;
            IsFrozen = true;
        }
    }
}