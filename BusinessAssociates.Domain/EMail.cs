namespace BusinessAssociates.Domain
{
    public class EMail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EMailAddress { get; set; }
        public bool IsPrimary { get; set; }
    }
}