namespace EGMS.BusinessAssociates.Query.ReadModels
{

    public class EGMSPermissionRM
    {
        public int Id { get; set; }

        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
        public bool IsActive { get; set; }
    }

    public class AlternateFuelRM
    {
        public int Id { get; set; }

        public string AlternateFuelName { get; set; }
        public string AlternateFuelDescription { get; set; }
    }
}