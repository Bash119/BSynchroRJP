namespace BSynchroRJP.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public decimal InitialCredit { get; set; }

        public decimal balance { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
