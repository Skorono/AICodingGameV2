using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace AICodingGame.API
{
    public class RobotStackFSM : MonoBehaviour
    {
        private readonly List<RobotTask> _actionStack = new();
        private bool _isExecuting = false;
        public int? ActionCount => _actionStack?.Count;

        public void PushAction(RobotTask action)
        {
            if (action != null)
                _actionStack.Add(action);
        }

        public RobotTask GetTopAction()
        {
            return ActionCount > 1 ? _actionStack[1] : _actionStack.First();
        }

        [CanBeNull]
        public RobotTask PopAction()
        {
            if (ActionCount > 1)
            {
                var action = GetTopAction();
                _actionStack.RemoveAt(1);
                return action;
            }

            return null;
        }

        public void ClearStack()
        {
            _actionStack.Clear();
        }

        public void ExecuteAction()
        {
            var work = GetTopAction();
            StartCoroutine(StartWork(work.Work(work.Parameters), work));
        }

        public IEnumerator StartWork(IEnumerator work, RobotTask task)
        {
            if (task.IsEnded == false)
            {
                StartCoroutine(work);
            }
            else
            {
                if (task.Work.Method.Name != "_Run")
                {
                    StopCoroutine(work);
                    PopAction();
                }
                else
                {
                    task.IsEnded = false;
                }
            }

            yield return new WaitForFixedUpdate();
        }

        public class RobotTask
        {
            public delegate IEnumerator CoroutineWork([CanBeNull] params object[] parameters);

            public object[] Parameters = { };

            public CoroutineWork Work = null;
            public bool IsEnded { get; set; }
        }
    }
}