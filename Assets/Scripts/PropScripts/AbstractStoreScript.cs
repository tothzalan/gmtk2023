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
            return (!hasChanged && !animator.GetBool(IsOpen)) || (!hasChanged && animator.GetBool(IsOpen) && gameManager.inventoryManager.UsingCurrently == ResourceType.Blackout);
        }

        public override void AttemptNeutralize()
        {
            if (hasChanged)
                return;
            hasChanged = true;
            bool isOpen = animator.GetBool(IsOpen);

            if (!isOpen)
                animator.SetBool(IsOpen, true);
        }

        public override void ExecuteInteraction()
        {
            if (gameManager.IsBlackOut)
                return;
            base.ExecuteInteraction();
        }
    }
}
