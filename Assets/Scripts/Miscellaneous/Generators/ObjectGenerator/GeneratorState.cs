using System.Threading.Tasks;
using Miscellaneous.Pools;
using UnityEngine;

namespace Miscellaneous.Generators.ObjectGenerator
{
	//Дублирует методы генератора
	public abstract class GeneratorState<T> where T : MonoBehaviour
	{
		protected MonoPool<T> MonoPool;

		protected GeneratorState(
			ref MonoPool<T> pool)
		{
			MonoPool = pool;
		}
		
		public virtual Task Create()
		{
			Debug.Log("Генерирую хуйню");
			return Task.CompletedTask;
		}

		public virtual Task Update()
		{
			Debug.Log("Обновляю хуйню");
			return Task.CompletedTask;
		}
	}
}