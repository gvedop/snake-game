using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame.Contracts
{
    public interface IWallController : IGameLogicSubscriber
    {
        void ToStart();
        void SetCount(int count);
    }
}
