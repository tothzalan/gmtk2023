using System;
using Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PropScripts
{
    public abstract class AbstractProp : MonoBehaviour, IPointerClickHandler
    {
        protected GameManager gameManager;
        protected MapGenerator mapGenerator;

        [NonSerialized]
        public bool hasNeutralized;
        // Start is called before the first frame update
        void Start()
        {
            gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            mapGenerator = GameObject.FindWithTag("GameController").GetComponent<MapGenerator>();
            TriggerStart();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left || !CanInteract() || hasNeutralized)
                return;
            AttemptNeutralize();
            FinalizeNeutralization();
        }

        public virtual void ExecuteInteraction()
        {
            gameManager.RemoveMoney(MoneyToRemove);
            gameManager.AddToxicity(ToxicityDifference);
            gameManager.AddScore(ScoreDifference);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlatformDestroy"))
            {
                Destroy(gameObject);
            }
        }

        public virtual void FinalizeNeutralization()
        {
            switch (gameManager.inventoryManager.UsingCurrently)
            {
                case ResourceType.Blackout: BlackoutResource.GetInstance().UseResource();
                    break;
                case ResourceType.Buoy: BuoyResource.GetInstance().UseResource();
                    break;
                case ResourceType.Police: PoliceResource.GetInstance().UseResource();
                    break;
            }
            gameManager.inventoryManager.UsingCurrently = ResourceType.None;
            hasNeutralized = true;
        }
    
        public void Destroy()
        {
            Destroy(gameObject);
        }

        protected virtual void TriggerStart()
        {
        
        }

        public abstract bool CanInteract();
        public abstract void AttemptNeutralize();
        public abstract int MoneyToRemove { get; }
        public abstract int ToxicityDifference { get; }
        public abstract int ScoreDifference { get; }
    }
}
