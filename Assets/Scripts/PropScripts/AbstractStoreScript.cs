using Enums;
using UnityEngine;

namespace PropScripts
{
    public abstract class AbstractStoreScript : AbstractProp
    {
        private Collider2D collider;
        // Update is called once per frame

        private ShopStatus status;
    
        public bool hasChanged;
        protected override void TriggerStart()
        {
            collider = gameObject.GetComponent<Collider2D>();
            
        }

        public override void AttemptNeutralize()
        {
            if (hasChanged)
                return;
            hasChanged = true;

            switch (status)
            {
                case ShopStatus.Closed: status = ShopStatus.Open;
                    break;
                case ShopStatus.Open: status = ShopStatus.Closed;
                    break;
            }
        }
    }
}
