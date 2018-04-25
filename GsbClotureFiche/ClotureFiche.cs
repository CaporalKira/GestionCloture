using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GsbClotureFiche
{
    public partial class ClotureFiche : ServiceBase
    {
        private string connectionString = "server=localhost;user id=userGsb;password=secret;database=gsb_frais;";
        private static System.Timers.Timer _timer;
        public const int HEURE = 3600000;

        public ClotureFiche()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {

            OnStart(null);
        }

       

        protected override void OnStart(string[] args)
        {

            try
            {
                // Créer un timer.
                _timer = new System.Timers.Timer();
                _timer.Interval = HEURE;
                _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                _timer.Enabled = true;
                _timer.Start();

            }
            catch (Exception ex)
            {
                creerLog("Création du timer : " + ex.ToString());
            }
        }

        protected override void OnStop()
        {
            try
            {
                // stopper le timer
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
            catch (Exception ex)
            {
                creerLog("Arrêt du timer : " + ex.ToString());
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (GestionDate.entre(1, 10))
            {
                cloturerFiches();
            }
            else if (GestionDate.entre(20, 31))
            {
                rembourserFiches();
            }
        }

        public void cloturerFiches()
        {
            string date = DateTime.Now.Year.ToString() + GestionDate.getMoisPrecedent();
            string req = " UPDATE fichefrais SET idetat = 'CL', datemodif = now() WHERE idetat = 'CR' AND  mois = " + date;
            try
            {
                ConnexionBDD conn = new ConnexionBDD(this.connectionString);
                conn.uneRequete(req);
            }
            catch (Exception ex)
            {
                creerLog("Cloture Fiches : " + ex.ToString());
            }
        }

        public void rembourserFiches()
        {
            string date = DateTime.Now.Year.ToString() + GestionDate.getMoisPrecedent();
            string req = " UPDATE fichefrais SET idetat = 'RB', datemodif = now() WHERE idetat = 'VA' OR idetat = 'MP' AND  mois = " + date;
            try
            {
                ConnexionBDD conn = new ConnexionBDD(this.connectionString);
                conn.uneRequete(req);
            }
            catch (Exception ex)
            {
                creerLog("Remboursement Fiches : " + ex.ToString());
            }
        }

        public void creerLog(string erreur)
        {
            string logFile = AppDomain.CurrentDomain.BaseDirectory + "log-" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
            string dateLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            System.IO.File.AppendAllText(logFile, dateLogFormat + erreur + Environment.NewLine);
        }
    }
}

