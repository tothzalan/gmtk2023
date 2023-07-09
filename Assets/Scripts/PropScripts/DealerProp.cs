using System;
using UnityEngine;
using Enums;

namespace PropScripts
{
    public class DealerProp : AbstractProp
    {
        [SerializeField]
        private GameObject police;

        private Rigidbody2D rigid;
        private Animator animator;
        private static readonly int Flee = Animator.StringToHash("Flee");

        public override int MoneyToRemove { get; } = 30;
        public override int ToxicityDifference { get; } = 20;
        public override int ScoreDifference { get; } = -50;

        protected override void TriggerStart()
        {
            rigid = gameObject.GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        }

        public override bool CanInteract()
        {
            return gameManager.inventoryManager.UsingCurrently == ResourceType.Police;
        }

        public override void AttemptNeutralize()
        {
            GameObject officer = Instantiate(police);
            officer.transform.position = new Vector3(transform.transform.position.x + 30, transform.position.y, -1);
            officer.GetComponent<PoliceOfficerScript>().isPlacedByPlayer = true;
            
            animator.SetTrigger(Flee);
        }

        private void Update()
        {
            if (hasNeutralized)
            {
                rigid.velocity = new Vector2(-1.0f * (1 + gameManager.SpeedMultiplier), 0);
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            
        }
    }
}