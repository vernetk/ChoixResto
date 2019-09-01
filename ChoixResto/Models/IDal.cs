using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoixResto.Models
{
    public interface IDal:IDisposable
    {
        //Restaurant
        List<Resto> ObtientTousLesRestaurants();
        void ModifierRestaurant(int id, string nom, string telephone);
        bool RestaurantExiste(string nom);
        void CreerRestaurant(string nom, string telephone);


        //Utilisateur
        Utilisateur ObtenirUtilisateur(int id);
        Utilisateur ObtenirUtilisateur(string idStr);
        int AjouterUtilisateur(string prenom, string motDePasse);
        Utilisateur Authentifier(string prenom, string motDePasse);
        bool ADejaVote(int idSondage, string idStr);


        //Sondage
        int CreerUnSondage();
        void AjouterVote(int idSondage, int idResto, int idUtilisateur);

        //Resultat
        List<Resultats> ObtenirLesResultats(int idSondage);
    }
}
