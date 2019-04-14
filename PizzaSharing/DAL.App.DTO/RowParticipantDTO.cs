namespace DAL.App.DTO
{
    public class RowParticipantDTO
    {
        public int LoanRowId { get; set; }

        public int AppUserId { get; set; }
        public string Name { get; set; }
        public decimal Involvement { get; set; }
        public int ReceiptRowId { get; set; }
    }
}