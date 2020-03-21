using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.Common
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}
