namespace SuperBank.Business
{
    public class Account
    {
        public string AccountNo { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }
        public bool IsActive { get; set; }
        

        public bool Deposit(double amount)
        {
            bool isDepositSuccessful = false;

            // Account must be active to make a deposit
            if (!this.IsActive)
                throw new InactiveAccountException("Can't deposit into inactive account");
            // Deposit amount must be greater than zero
            if (amount <= 0)
            {
                throw new InvalidAmountException("Deposit amount must be greater than zero");
            }
            // throw an exception if the account is not active or if the deposit amount is invalid
            // If the deposit is successful, update the balance then return true; otherwise, return false
            //


            Balance += amount;
            isDepositSuccessful = true;
            return isDepositSuccessful;

        }

        public bool Withdraw(double amount, int pin) 
        {
            bool isWithdrawSuccessful = false;

            // add business rules for withdraw here
            // Account must be active to make a withdrawal
            if(!IsActive)
            {
                throw new InactiveAccountException("Can't withdraw from inactive account");
            }

            // Withdrawal amount must be greater than zero and less than or equal to the current balance
            if(amount <= 0 || amount > Balance)
            {
                throw new InvalidAmountException("Withdrawal amount must be greater than zero and less than or equal to the current balance");
            }
            // Pin must be correct
            if(this.Pin != pin)
            {
                throw new InvalidPinException("Incorrect pin");
            }
            // throw an exception if the account is not active, if the withdrawal amount is invalid, or if the pin is incorrect



            Balance -= amount;
            isWithdrawSuccessful = true;
            return isWithdrawSuccessful;
        }


    }
}
