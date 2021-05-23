using UnityEngine;

namespace Assets.Scripts.Common.Providers
{
    /*
     * ProviderField keep link to a service for all client monobehaviour lifetime.
     * For example if you subscribe to event in a service, and then change a scene.
     * If you try unsubscribe on destroy you can catch nullref becouse provider destroyed
     * before your class. ProviderField keeps that link inside your client monobehaviour.
     */
    public abstract class ProviderField<TProvider, TService>
        where TProvider : MonoBehaviour 
    {
        [SerializeField] TProvider _provider;
        private TService _service;

        protected abstract TService GetService(TProvider provider);

        public void Awake()
        {

            if (_service == null)
            {
                if (_provider == null)
                    throw new System.Exception("Provider field is not setted");
               
                _service = GetService(_provider);

                if (_service == null)
                    throw new System.Exception("Provider must be setted before awake");
            }
        }

        public TService Get()
        {
            Awake();
            return _service;
        }
    }
}
