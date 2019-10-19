using ChoixResto.Controllers;
using ChoixResto.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChoixResto.Tests
{
    [TestClass]
    class RestaurantControllerTests
    {

        [TestMethod]
        public void RestaurantController_ModifierRestaurantAvecRestoInvalideEtBindingDeModele_RenvoiVueParDefaut()
        {
            RestaurantController controller = new RestaurantController(new DalEnDur());
            Resto resto = new Resto { Id = 1, Nom = null, Telephone = "0102030405" };
            controller.ValideLeModele(resto);

            ViewResult resultat = (ViewResult)controller.ModifierRestaurant(resto);

            Assert.AreEqual(string.Empty, resultat.ViewName);
            Assert.IsFalse(resultat.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void RestaurantController_ModifierRestaurantAvecRestoValide_CreerRestaurantEtRenvoiVueIndex()
        {
            using (IDal dal = new DalEnDur())
            {
                RestaurantController controller = new RestaurantController(dal);
                Resto resto = new Resto { Id = 1, Nom = "Resto mate", Telephone = "0102030405" };
                controller.ValideLeModele(resto);

                RedirectToRouteResult resultat = (RedirectToRouteResult)controller.ModifierRestaurant(resto);

                Assert.AreEqual("Index", resultat.RouteValues["action"]);
                Resto restoTrouve = dal.ObtientTousLesRestaurants().First();
                Assert.AreEqual("Resto mate", restoTrouve.Nom);
            }
        }
    }
}
