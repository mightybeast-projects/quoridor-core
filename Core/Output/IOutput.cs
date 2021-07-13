using System;

namespace Quoridor.Core.Output
{
    public interface IOutput : IMovementOutput
    {
        void DisplayExceptionMessage(Exception e);
    }
}