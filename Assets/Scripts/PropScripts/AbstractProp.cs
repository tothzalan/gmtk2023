using System;
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
            if (other.gameObject.CompareTag("PlatformDestroy"))
            {
                Destroy(gameObject);
            }
        }

        public void FinalizeNeutralization()
        {
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
