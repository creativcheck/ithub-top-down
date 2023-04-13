using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyCollection
    {
        private List<Enemy> _enemies;

        public EnemyCollection()
        {
            _enemies = new List<Enemy>();
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        public bool CheckWinCondition()
        {
            if (_enemies.Count == 0)
                return true;

            return false;
        }

    }

}
