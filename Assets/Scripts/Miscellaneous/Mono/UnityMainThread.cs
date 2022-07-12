using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class UnityMainThread : MonoBehaviour
{
	public static UnityMainThread InstanceUnityMainThread;
	private readonly Queue<Task> _jobs = new Queue<Task>();

	private void Awake() {
		if (InstanceUnityMainThread == null) InstanceUnityMainThread = this;   
		else if (InstanceUnityMainThread == this) Destroy(gameObject);
		DontDestroyOnLoad(this);
	}

	private void Update() {
		while (_jobs.Count > 0)
		{
			var job = _jobs.Dequeue();
			job.GetAwaiter().GetResult();
			Debug.Log("мм");
		}
	}

	public void AddJob(Task newJob) {
		_jobs.Enqueue(newJob);
	}
}