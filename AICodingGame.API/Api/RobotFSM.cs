using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AICodingGame.API
{
    public class RobotStackFSM
    {
        private Stack<Action> _actionStack = new Stack<Action>();
        
        public void PushAction(Action action) {
            if ((_actionStack.FirstOrDefault() != action) && (action != null))
                _actionStack.Push(action);
        }

        public Action PopAction()
        {
            _actionStack.TryPop(out Action action);
            return action;
        }

        public void ClearStack() => _actionStack.Clear();

        public int? GetStackSize => _actionStack?.Count;

        public void ExecuteAction() => _actionStack.Peek()();   
    }
}