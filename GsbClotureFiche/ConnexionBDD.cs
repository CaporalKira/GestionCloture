using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace GsbClotureFiche
{
    class ConnexionBDD
    {
        // propriétés 

        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private bool finCurseur = true;

        // constructeur

        public ConnexionBDD(string chaineConnection)
        {
            this.connection = new MySqlConnection(chaineConnection);
            this.connection.Open();
        }

        // requete select

        public void select(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connection);
            this.reader = this.command.ExecuteReader();
            this.finCurseur = false;
            this.suivant();
        }

        // requete insert,update,delete

        public void uneRequete(string chaineRequete)
        {
            this.command = new MySqlCommand(chaineRequete, this.connection);
            this.command.ExecuteNonQuery();
            this.finCurseur = true;
        }

        // récupérer un champ
        public Object champ(string nomChamp)
        {
            return this.reader[nomChamp];
        }

        // avancer le curseur à la ligne suivante

        public void suivant()
        {
            if (!this.finCurseur)
            {
                this.finCurseur = !this.reader.Read();
            }
        }

        // test de la fin du curseur

        public Boolean fin()
        {
            return this.finCurseur;
        }

        // fermeture de la connexion

        public void close()
        {
            this.connection.Close();
        }
    }
}
