using System.Threading.Tasks;

namespace Miscellaneous.GC
{
	//Сборщик бизнесс мусора по заданным правилам
	public abstract class BusinessGarbageCollector
	{
		private BusinessGarbageCollectorStrategy _currentStrategy;

		protected BusinessGarbageCollector(BusinessGarbageCollectorStrategy workingStrategy)
		{
			_currentStrategy = workingStrategy;
		}

		public virtual async Task DoJob()
		{
			//Ну типа идея такая что собрищик хуйни не знает что он делает и можно будет потом менять контекст его работы
			await _currentStrategy.DestroyFuckingObjects();
		}
		
		public void SwitchStrategy(BusinessGarbageCollectorStrategy newStrategy)
		{
			_currentStrategy = newStrategy;
		}
	}
}
