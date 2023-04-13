using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using Services;

namespace Enemy
{
    public class FinishZone : MonoBehaviour
    {
        [SerializeField] private int _nextLevel;
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private LayerMask _characterLayer;

        public EnemyCollection EnemyCollection {get; private set;}

        private void Awake()
        {
            EnemyCollection = new EnemyCollection();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(Utils.IsInLayerMask(collision.gameObject.layer, _characterLayer))
            {
                CheckWin();
            }
        }

        private void CheckWin()
        {
            if(EnemyCollection.CheckWinCondition())
            {
                _inputListener.Expose();
                SceneController.NextLevel(_nextLevel);
            }
        }
    }

}