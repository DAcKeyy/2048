using System.Threading.Tasks;
using UnityEngine;

namespace Miscellaneous.StateMachines.Mono
{
	public abstract class MonoState
	{
		public Task CurrentTask { get; protected set; }
		
		/*
		public virtual Task DoJob()
		{
			CurrentTask = Job();
			
			return CurrentTask;
		}
*/
		private Task Job()
		{
			//lOGIC
			return Task.CompletedTask;
		}
	}
}