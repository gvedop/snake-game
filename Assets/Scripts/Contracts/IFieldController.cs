using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Contracts
{
    public interface IFieldController : IGameLogicSubscriber
    {
        void Init();
    }
}
