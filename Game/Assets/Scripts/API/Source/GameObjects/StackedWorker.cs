using AICodingGame.API;
using UnityEngine;

namespace API.Source.GameObjects
{
    public class StackedWorker : MonoBehaviour
    {
        protected RobotStackFSM _fsm;
        private bool _turnIsEnd;


        public void Execute()
        {
            _fsm.ExecuteAction();

            _turnIsEnd = false;
        }
    }
}