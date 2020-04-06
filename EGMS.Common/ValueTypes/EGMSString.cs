using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.Common.ValueTypes
{
    namespace EGMS.Common.ValueTypes
    {
        public class EGMSString<T> : EGMSValue<T>
            where T : EGMSString<T>
        {
            protected EGMSString(string text)
            {
                // TODO - validation 

                Value = text;
            }

            protected EGMSString() { }

            public string Value { get; }

            public static implicit operator string(EGMSString<T> text)
            {
                return text.Value;
            }
        }
    }
}
