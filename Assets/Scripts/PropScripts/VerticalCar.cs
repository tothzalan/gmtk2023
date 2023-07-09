using System;
using UnityEngine;

namespace PropScripts
{
    public class VerticalCar : AbstractProp
    {
        private Rigidbody2D rigid;
        
        public override bool CanInteract()
        {
            return false;
        }

        protected override void TriggerStart()
        {
            rigid = gameObject.GetComponent<Rigidbody2D>();
        }

        public override void AttemptNeutralize()
        {
        }

        void FixedUpdate()
        {
            rigid.velocity = new Vector2(0, -2 * gameManager.Speed);
        }

        public override void ExecuteInteraction()
        {
            gameManager.Dead = true;
            gameManager.killedBy = "Car";
        }

        public override int MoneyToRemove { get; }
        public override int ToxicityDifference { get; }
        public override int ScoreDifference { get; }
    }
}