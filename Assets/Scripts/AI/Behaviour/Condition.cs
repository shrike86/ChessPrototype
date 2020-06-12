using ChessPrototype.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    public abstract class Condition : ScriptableObject
    {
		public string description;

        public abstract bool CheckCondition(AIManager ai);

    }
}
