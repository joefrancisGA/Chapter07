

using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class DepartmentCode : Value<DepartmentCode>
    {
        public string Value { get; }

        public DepartmentCode() { }

        private DepartmentCode(string value)
        {
            Value = value;
        }

        public static DepartmentCode Create(string departmentCode)
        {
            return new DepartmentCode(departmentCode);
        }

        public static implicit operator string(DepartmentCode departmentCode)
        {
            return departmentCode.Value;
        }

        public static explicit operator DepartmentCode(string departmentCode)
        {
            return new DepartmentCode(departmentCode);
        }
    }
}