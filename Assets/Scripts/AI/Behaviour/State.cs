using System.Collections.Generic;
using UnityEngine;

namespace ChessPrototype.AI
{
    [CreateAssetMenu(menuName = "Behaviour/AI/State")]
    public class State : ScriptableObject
    {
    	public AIStateActions[] onFixed;
        public AIStateActions[] onUpdate;
        public AIStateActions[] onEnter;
        public AIStateActions[] onExit;

        public int idCount;
		[SerializeField]
        public List<Transition> transitions = new List<Transition>();

        public void OnEnter(AIManager ai)
        {
            ExecuteActions(ai, onEnter);
        }
	
		public void FixedTick(AIManager ai)
		{
			ExecuteActions(ai,onFixed);
            CheckTransitions(ai);
        }

        public void Tick(AIManager ai)
        {
            ExecuteActions(ai, onUpdate);
            CheckTransitions(ai);
        }

        public void OnExit(AIManager ai)
        {
            ExecuteActions(ai, onExit);
        }

        public void CheckTransitions(AIManager ai)
        {
            for (int i = 0; i < transitions.Count; i++)
            {
                if (transitions[i].disable)
                    continue;

                if(transitions[i].condition.CheckCondition(ai))
                {
                    if (transitions[i].targetState != null)
                    {
                        OnExit(ai);
                        ai.currentState = transitions[i].targetState;
                        ai.currentState.OnEnter(ai);
                    }
                    return;
                }
            }
        }
        
        public void ExecuteActions(AIManager ai, AIStateActions[] l)
        {
            for (int i = 0; i < l.Length; i++)
            {
                if (l[i] != null)
                    l[i].Execute(ai);
            }
        }

        public Transition AddTransition()
        {
            Transition retVal = new Transition();
            transitions.Add(retVal);
            retVal.id = idCount;
            idCount++;
            return retVal;
        }

        public Transition GetTransition(int id)
        {
            for (int i = 0; i < transitions.Count; i++)
            {
                if (transitions[i].id == id)
                    return transitions[i];
            }

            return null;
        }

		public void RemoveTransition(int id)
		{
			Transition t = GetTransition(id);
			if (t != null)
				transitions.Remove(t);
		}

    }
}
