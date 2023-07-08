using System;
using Enums;
using UnityEngine;

namespace PropScripts
{
    public abstract class AbstractStoreScript : AbstractProp
    {
        private ShopStatus status = ShopStatus.Open;
    
        public bool hasChanged;

        protected override void TriggerStart()
        {
            System.Random rand = new System.Random();

            if (rand.Next(4) == 0)
                status = ShopStatus.Closed;
        }

        public override bool CanInteract()
        {
            return status == ShopStatus.Open;
        }

        public override void AttemptNeutralize()
        {
            if (hasChanged)
                return;
            hasChanged = true;

            if (status == ShopStatus.Closed)
                status = ShopStatus.Open;
            else /*Requires access to resource use*/
            {
                
            }
            
            FinalizeNeutralization();
        }
    }
}
