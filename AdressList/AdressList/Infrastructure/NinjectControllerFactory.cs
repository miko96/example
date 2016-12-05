using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdressList.Models;
using Ninject;

namespace AdressList.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
        public object GetService(Type serviceType)
        { return kernel.TryGet(serviceType); }
        public IEnumerable<object> GetServices(Type serviceType)
        { return kernel.GetAll(serviceType); }
        private void AddBindings()
        {
            //Mock<IAdressListRepository> mock = new Mock<IAdressListRepository>();
            //mock.Setup(m => m.AdressNotes).Returns(new List<AdressNote>
            //{
            //    new AdressNote {AdressNoteId = 1, PersonName = "Игра1", Adress = "Кат1" }
            //    });
            kernel.Bind<IAdressListRepository>().To<AdressListRepository>();
        }
    }
}