namespace BSynchroRJP.Models
{
    public class UserSheet
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public decimal Balance { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
