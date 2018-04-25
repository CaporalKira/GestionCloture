using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsbClotureFiche
{
    public abstract class GestionDate
    {
        /// <summary>
        /// retourne le mois precedant le moment de l'exécution de la commande en format 'mm'
        /// </summary>
        /// <returns>string 'mm'</returns>
        public static string getMoisPrecedent()
        {
            DateTime moisPrecedent = DateTime.Now.AddMonths(-1);
            return moisPrecedent.ToString().Substring(3, 2);
        }

        // retourne le mois precedant une date donnée en format 'mm'
        /// <summary>
        /// retourne le mois precedant une date donnée en format 'mm'
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns> string 'mm'</returns>
        public static string getMoisPrecedent(DateTime date)
        {
            DateTime moisPrecedent = date.AddMonths(-1);
            return moisPrecedent.ToString().Substring(3, 2);
        }

        /// <summary>
        /// retourne le mois suivant le moment de l'exécution de la commande en format 'mm'
        /// </summary>
        /// <returns>string 'mm'</returns>
        public static string getMoisSuivant()
        {
            DateTime moisPrecedent = DateTime.Now.AddMonths(1);
            return moisPrecedent.ToString().Substring(3, 2);
        }


        /// <summary>
        /// retourne le mois suivant une date donnée 
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>string 'mm'</returns>
        public static string getMoisSuivant(DateTime date)
        {
            DateTime moisPrecedent = date.AddMonths(1);
            return moisPrecedent.ToString().Substring(3, 2);
        }

        /// <summary>
        /// retourne vrai si le jour actuel appartient a un interval donné
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>bool</returns>
        public static bool entre(int min, int max)
        {
            if (min <= DateTime.Now.Day && DateTime.Now.Day <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// retourne vrai si un jour donné appartient a un interval donné
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="date">The date.</param>
        /// <returns>bool</returns>
        public static bool entre(int min, int max, DateTime date)
        {
            if (min <= date.Day && date.Day <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
