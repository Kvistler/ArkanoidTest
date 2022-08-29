using System.Collections.Generic;
using UnityEngine;

namespace BrickSpawners
{
	public interface ISpawner
	{
		void SpawnBricksSet();
		List<GameObject> GetBricksSet();
	}
}