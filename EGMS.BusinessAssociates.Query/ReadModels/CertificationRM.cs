using System;

namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class PhoneRM
    {
        public int Id { get; set; }


    }

    public class CertificationRM
    {
        public int Id { get; set; }

        public bool IsInherited { get; set; }
        public int CertificationStatusId { get; set; }
        public DateTime CertificationDateTime { get; set; }
        public DateTime DecertificationDateTime { get; set; }
    }
}