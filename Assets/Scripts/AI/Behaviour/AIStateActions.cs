using ChessPrototype.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    public abstract class AIStateActions : ScriptableObject
    {
        public abstract void Execute(AIManager ai);
    }
}
