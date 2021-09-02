using UnityEngine;

namespace Tools.Logger
{
    internal class DebugLogger: ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}