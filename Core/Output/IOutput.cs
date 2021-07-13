using System;

namespace Quoridor.Core.Output
{
    public interface IOutput
    {
        void DisplayExceptionMessage(Exception e);
    }
}