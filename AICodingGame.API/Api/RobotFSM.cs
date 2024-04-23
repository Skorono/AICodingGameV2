using System;
using System.Collections.Generic;
using System.Linq;

namespace AICodingGame.API
{
    public class RobotStackFSM
    {
        private readonly Stack<Action> _actionStack = new Stack<Action>();

        public int? GetStackSize => _actionStack?.Count;

        public void PushAction(Action action)
        {
            if (_actionStack.FirstOrDefault() != action && action != null)
                _actionStack.Push(action);
        }

        public Action PopAction()
        {
            _actionStack.TryPop(out var action);
            return action;
        }

        public void ClearStack()
        {
            _actionStack.Clear();
        }

        public void ExecuteAction()
        {
            _actionStack.Peek()();
        }
    }
}