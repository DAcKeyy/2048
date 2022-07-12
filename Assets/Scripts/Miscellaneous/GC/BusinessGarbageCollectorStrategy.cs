using System.Threading.Tasks;
using Miscellaneous.Pools;
using UnityEngine;

namespace Miscellaneous.GC
{
	//Асинхронная стратегия сборщика игрового мусора
	public abstract class BusinessGarbageCollectorStrategy
	{
		private readonly MonoPool<MonoBehaviour> _pool;

		protected BusinessGarbageCollectorStrategy(ref MonoPool<MonoBehaviour> monoPool)
		{
			_pool = monoPool;
		}

		//По умолчанию уничтожает весь данный ему пул
		public virtual Task DestroyFuckingObjects()
		{
			for (var i = 0; i < _pool.PrefabPool.Count; i++)
			{
				_pool.PrefabPool.RemoveAt(i);
			}

			return Task.CompletedTask;
		}
	}
}