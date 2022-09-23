using System.Collections.Generic;

public static class Extensions
{

	#region Queue

	public static T CycleItem<T>(this Queue<T> queue)
	{
		if(queue.Count > 0)
		{
			T firstItem = queue.Dequeue();
			queue.Enqueue(firstItem);
			return firstItem;
		}

		return default;
	}

	public static void EnqueueRange<T>(this Queue<T> queue, T[] newItems)
	{
		for(int i = 0, count = newItems.Length; i < count; i++)
		{
			queue.Enqueue(newItems[i]);
		}
	}

	#endregion
}