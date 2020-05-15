using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowTransport.ApplicationServices.Ports
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse response);
    }
}
