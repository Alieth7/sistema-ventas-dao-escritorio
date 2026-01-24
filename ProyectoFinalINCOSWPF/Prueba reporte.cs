using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



using DAOSisVen.Model;
using DAOSisVen.Implementation;
//
using CrystalDecisions.CrystalReports.Engine;
using System.Windows;


namespace ProyectoFinalINCOSWPF
{
    public partial class Prueba_reporte : Form
    {

        MessageBoxPerso mensajePer;
        public Prueba_reporte()
        {
            InitializeComponent();
            //CargarReporte();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                UsuarioImpl implusuario = new UsuarioImpl();

                ReporteGeneral reporteGeneral = new ReporteGeneral();
                reporteGeneral.Load(@"~\ReporteGeneral.rtp");
                DataTable datos = implusuario.filtrarRol("Administrador");//estamos probando con administrador
                reporteGeneral.SetDataSource(datos);

                // Establece la fuente de datos para el reporte
                reporteGeneral.SetDataSource(datos);

                // Asigna el reporte al CrystalReportViewer existente
                crystalReportViewer1.ReportSource = reporteGeneral;

                // Refresca el viewer
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {

                mensajePer = new MessageBoxPerso(ex.Message);
                mensajePer.Show();
            }
            
        }

        //ReportDocument reportDocument = new ReportDocument();
        //ReportDocument.Load(\);
    }
}
