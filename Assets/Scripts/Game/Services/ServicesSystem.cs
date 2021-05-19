using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game.Services
{
    public class ServicesSystem
    {
        private GameCore _core;
        private Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public ServicesSystem(GameCore core)
        {
            _core = core;
        }

        public T Get<T>() where T : IService
        {
            return (T)_services[typeof(T)];
        }

        public void Add(IService service)
        {
            _services.Add(service.GetType(), service);
        }

        public void Remove(IService service)
        {
            _services.Remove(service.GetType());
        }
    }
}
