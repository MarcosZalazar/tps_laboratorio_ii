﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using EntidadesNegocio;
using Serializacion;


namespace Vista
{
    public partial class FrmPrincipal : Form
    {
        public string primerArchivoSocio;
        public string primerArchivoProfesor;
        public static string nombreArchivo;
        public static string nombreArchivoProfesor;
        public static string fichaSocio;
        public static string nombreArchivoEgreso;
        public Gimnasio gimnasio;

        static FrmPrincipal()
        {
            nombreArchivo = "ListaSocios.xml";
            nombreArchivoProfesor = "ListaProfesores.xml";
            fichaSocio = "fichaSocio.txt";
            nombreArchivoEgreso = "listaEgresos.xml";
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            this.gimnasio = new Gimnasio("Espartanos");
            this.primerArchivoSocio=AppDomain.CurrentDomain.BaseDirectory + "MockSocio.xml";
            this.primerArchivoProfesor = AppDomain.CurrentDomain.BaseDirectory + "MockProfesores.xml";
        }

        /// <summary>
        /// Carga a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipalDeSocio_Load(object sender, EventArgs e)
        {
            
            if (File.Exists(nombreArchivo))
            {
                this.gimnasio.ListaSocios = ClaseSerializadora<List<Socio>>.Leer(nombreArchivo);
            }
            else
            {
                
                this.gimnasio.ListaSocios = ClaseSerializadora<List<Socio>>.Leer(primerArchivoSocio);
            }

            if (File.Exists(nombreArchivoProfesor))
            {
                this.gimnasio.ListaProfesores = ClaseSerializadora<List<Profesor>>.Leer(nombreArchivoProfesor);
            }
            else
            {
                this.gimnasio.ListaProfesores = ClaseSerializadora<List<Profesor>>.Leer(primerArchivoProfesor);
            }

            RefrescarLista();
        }

        /// <summary>
        /// Actualiza las listas
        /// </summary>
        private void RefrescarLista()
        {
            this.lstSocios.DataSource = null;
            this.lstSocios.DataSource = this.gimnasio.ListaSocios;
            this.lstProfesores.DataSource = null;
            this.lstProfesores.DataSource = this.gimnasio.ListaProfesores;
        }

        /// <summary>
        /// Agrega a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarAlSocio_Click(object sender, EventArgs e)
        {
            FrmAgregarModificarSocio frmAgregarModificarSocio = new FrmAgregarModificarSocio("Agregar socio", "Agregar", null);
            DialogResult resultado = frmAgregarModificarSocio.ShowDialog();

            if (frmAgregarModificarSocio.DevolverSocio is not null && resultado == DialogResult.OK)
            {
                this.gimnasio.ListaSocios.Add(frmAgregarModificarSocio.DevolverSocio);
                ClaseSerializadora<List<Socio>>.Escribir(this.gimnasio.ListaSocios, nombreArchivo);
                this.RefrescarLista();
                MessageBox.Show("Socio agregado", "Socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// MOdifica a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarAlSocio_Click(object sender, EventArgs e)
        {
            Socio socioSeleccionado = (Socio) this.lstSocios.SelectedItem;

            if (socioSeleccionado is not null)
            {
                FrmAgregarModificarSocio frmModificarSocio = new FrmAgregarModificarSocio("Modificar socio", "Modificar", socioSeleccionado);
                frmModificarSocio.ShowDialog();

                if (frmModificarSocio.DialogResult == DialogResult.OK)
                {
                    int indice = this.gimnasio.ListaSocios.IndexOf(socioSeleccionado);
                    this.gimnasio.ListaSocios[indice] = frmModificarSocio.DevolverSocio;
                    ClaseSerializadora<List<Socio>>.Escribir(this.gimnasio.ListaSocios, nombreArchivo);
                    RefrescarLista();
                    MessageBox.Show("Socio modificado", "Socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarAlSocio_Click(object sender, EventArgs e)
        {
            Socio socioSeleccionado = (Socio)this.lstSocios.SelectedItem;

            if (socioSeleccionado is not null)
            {
                this.gimnasio.ListaSocios.Remove(socioSeleccionado);
                ClaseSerializadora<List<Socio>>.Escribir(this.gimnasio.ListaSocios, nombreArchivo);
                RefrescarLista();
                MessageBox.Show("Socio eliminado", "Socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Imprime una ficha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimirFicha_Click(object sender, EventArgs e)
        {
            Socio socioSeleccionado = (Socio)this.lstSocios.SelectedItem;

            if (socioSeleccionado is not null)
            {
                string contenido = this.gimnasio.ImprimirFichaDelSocio(socioSeleccionado);
                string nombreFicha = "Ficha de "+socioSeleccionado.Nombre + socioSeleccionado.Apellido+".txt";
                ClaseSerializadora<string>.EscribirEnTxt(nombreFicha, contenido);
                MessageBox.Show("Ficha impresa", "Socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra mensajes de error
        /// </summary>
        /// <param name="ex"></param>
        private void MostrarMensajeDeError(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(ex.Message);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(ex.StackTrace);

            MessageBox.Show(stringBuilder.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Agrega a un profesor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarProfesor_Click(object sender, EventArgs e)
        {
            FrmAgregarModificarProfesores frmAgregarModificarProfesor = new FrmAgregarModificarProfesores("Agregar profesor", "Agregar", null);
            DialogResult resultado = frmAgregarModificarProfesor.ShowDialog();

            if (frmAgregarModificarProfesor.DevolverProfesor is not null && resultado == DialogResult.OK)
            {
                this.gimnasio.listaProfesores.Add(frmAgregarModificarProfesor.DevolverProfesor);
                ClaseSerializadora<List<Profesor>>.Escribir(this.gimnasio.ListaProfesores, nombreArchivoProfesor);
                this.RefrescarLista();
                MessageBox.Show("Profesor agregado", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Modifica a un profesor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            Profesor profesorSeleccionado = (Profesor)this.lstProfesores.SelectedItem;

            if (profesorSeleccionado is not null)
            {
                FrmAgregarModificarProfesores frmModificarProfesor = new FrmAgregarModificarProfesores("Modificar profesor", "Modificar", profesorSeleccionado);
                frmModificarProfesor.ShowDialog();

                if (frmModificarProfesor.DialogResult == DialogResult.OK)
                {
                    int indice = this.gimnasio.listaProfesores.IndexOf(profesorSeleccionado);
                    this.gimnasio.listaProfesores[indice] = frmModificarProfesor.DevolverProfesor;
                    ClaseSerializadora<List<Profesor>>.Escribir(this.gimnasio.ListaProfesores, nombreArchivoProfesor);
                    RefrescarLista();
                    MessageBox.Show("Profesor modificado", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Elimina a un profesor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarProfesor_Click(object sender, EventArgs e)
        {
            Profesor profesorSeleccionado = (Profesor)this.lstProfesores.SelectedItem;

            if (profesorSeleccionado is not null)
            {
                this.gimnasio.ListaProfesores.Remove(profesorSeleccionado);
                ClaseSerializadora<List<Profesor>>.Escribir(this.gimnasio.ListaProfesores, nombreArchivoProfesor);
                RefrescarLista();
                MessageBox.Show("Profesor eliminado", "Profesor", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Muestra por pantalla la informacion de gestion del gimnasio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarInfoGestion_Click(object sender, EventArgs e)
        {
            this.rtbGestion.Text=this.gimnasio.InformacionGestion();
        }

        /// <summary>
        /// Limpia el informe de gestion de la pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiarInforme_Click(object sender, EventArgs e)
        {
            this.rtbGestion.Text = "";
        }

        /// <summary>
        /// Registra manualmente egresos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistrarEgresos_Click(object sender, EventArgs e)
        {
            FrmAgregarEgresos frmAgregarEgreso = new FrmAgregarEgresos(null);
            DialogResult resultado = frmAgregarEgreso.ShowDialog();

            if (frmAgregarEgreso.DevolverEgreso is not null && resultado == DialogResult.OK)
            {
                this.gimnasio.PeriodoComercial.Egresos.Add(frmAgregarEgreso.DevolverEgreso);
                ClaseSerializadoraJson<List<Egreso>>.Escribir(this.gimnasio.PeriodoComercial.Egresos, nombreArchivoEgreso);
                MessageBox.Show("Egreso agregado", "Egresos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Importa un archivo de egresos en formato Json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportarEgresos_Click(object sender, EventArgs e)
        {
            this.gimnasio.PeriodoComercial.Egresos=ClaseSerializadoraJson<List<Egreso>>.Leer(nombreArchivoEgreso);
            MessageBox.Show("Egreso importado con éxito", "Egresos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
