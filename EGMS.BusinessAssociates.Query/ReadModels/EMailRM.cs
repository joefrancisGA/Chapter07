namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class EMailRM
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string EMailAddress { get; set; }
        public bool IsPrimary { get; set; }
        public int ContactId { get; set; }
    }
}