using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Miscellaneous.StateMachines.Mono
{
	public abstract class MonoStateMachine<T> : MonoBehaviour where T : MonoState
	{
		public List<T> StatesList { get; protected set; }
		public T CurrentState { get; protected set; }

		public MonoStateMachine()
		{
			StatesList = new List<T>();
		}
		
		/*
		public virtual async Task DoJob()
		{
			await CurrentState.DoJob();
		}
		*/
		public async Task SwitchState<TMonoState>(TMonoState newState) where TMonoState : MonoState
		{
			var state = StatesList.FirstOrDefault(x => x is TMonoState);
			if(state == null) throw new NotFiniteNumberException($"{typeof(TMonoState)} not initialized in states list");

			await CurrentState.CurrentTask;
			CurrentState = state;
		}
	}
}