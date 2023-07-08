using System;
using Enums;
using UnityEngine;

namespace PropScripts
{
    public abstract class AbstractStoreScript : AbstractProp
    {
        private Animator animator;

        public bool hasChanged;
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");

        protected override void TriggerStart()
        {
            animator = gameObject.GetComponent<Animator>();
            System.Random rand = new System.Random();

            if (rand.Next(4) == 0)
                animator.SetBool(IsOpen, false);
        }

        public override bool CanInteract()
        {
            return !hasChanged;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
        }

        public override void AttemptNeutralize()
        {
            if (hasChanged)
                return;
            hasChanged = true;
            bool isOpen = animator.GetBool(IsOpen);

            if (!isOpen)
                animator.SetBool(IsOpen, true);
            else /*Requires access to resource use*/
            {
                
            }
            
            FinalizeNeutralization();
        }
    }
}
