using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using EntidadesNegocio;
using GimnasioException;
using Serializacion;


namespace Vista
{
    public partial class FrmPrincipal : Form
    {
        public string primerArchivoSocio;
        public static string nombreArchivoSocio;
        public static string fichaSocio;
        public static string nombreArchivoEgreso;
        public Gimnasio gimnasio;

        static FrmPrincipal()
        {
            nombreArchivoSocio = "ListaSocios.xml";
            fichaSocio = "fichaSocio.txt";
            nombreArchivoEgreso = "listaEgresos.xml";
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            this.gimnasio = new Gimnasio("Espartanos");
            this.primerArchivoSocio=AppDomain.CurrentDomain.BaseDirectory + "MockSocio.xml";
            this.gimnasio.NotificacionEnviada += InformarNecesidadDeProfesores;
        }

        /// <summary>
        /// Carga a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipalDeSocio_Load(object sender, EventArgs e)
        {
            if (File.Exists(nombreArchivoSocio))
            {
                this.gimnasio.listaSocios = ClaseSerializadora<List<Socio>>.Leer(nombreArchivoSocio);
            }
            else
            {
                this.gimnasio.listaSocios = ClaseSerializadora<List<Socio>>.Leer(primerArchivoSocio);
            }

            this.gimnasio.ListaProfesores = GestorSQL.LeerDatosProfesor();
            RefrescarLista();
        }

        /// <summary>
        /// Actualiza las listas
        /// </summary>
        private void RefrescarLista()
        {
            this.lstSocios.DataSource = null;
            this.lstProfesores.DataSource = null;

            List<Socio> listaAuxiliarSocios=new List<Socio>();
            foreach (Socio socio in this.gimnasio.listaSocios)
            {
                if (socio.SocioActivo == true)
                {
                    listaAuxiliarSocios.Add(socio);
                }
            }
            this.lstSocios.DataSource = listaAuxiliarSocios;

            List<Profesor> listaAuxiliarProfesores = new List<Profesor>(); 
            foreach (Profesor profesor in this.gimnasio.ListaProfesores)
            {
                if (profesor.ProfesorActivo == true)
                {
                    listaAuxiliarProfesores.Add(profesor);
                }
            }
            this.lstProfesores.DataSource = listaAuxiliarProfesores;
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

            try
            {
                if (frmAgregarModificarSocio.DevolverSocio is not null && resultado == DialogResult.OK)
                {
                    if (this.gimnasio.estaElSocioEnLaLista(frmAgregarModificarSocio.DevolverSocio) == false)
                    {
                        this.gimnasio.listaSocios.Add(frmAgregarModificarSocio.DevolverSocio);
                        ClaseSerializadora<List<Socio>>.Escribir(this.gimnasio.listaSocios, nombreArchivoSocio);
                        this.RefrescarLista();
                        MessageBox.Show("Socio agregado", "Socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        throw new PersonaException("Intento de carga duplicada de socio");
                    }
                }
            }
            catch (PersonaException)
            {
                MessageBox.Show("Error.El socio ya es miembro del gimnasio. Verifique los datos nuevamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Error.No se pudo realizar la carga del socio. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.gimnasio.EvaluarNecesidadDeProfesores();
        }

        /// <summary>
        /// Modifica a un socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarAlSocio_Click(object sender, EventArgs e)
        {
            Socio socioSeleccionado = (Socio) this.lstSocios.SelectedItem;

            try
            {
                if (socioSeleccionado is not null)
                {
                    FrmAgregarModificarSocio frmModificarSocio = new FrmAgregarModificarSocio("Modificar socio", "Modificar", socioSeleccionado);
                    frmModificarSocio.ShowDialog();

                    if (frmModificarSocio.DialogResult == DialogResult.OK)
                    {
                        int indice = this.gimnasio.listaSocios.IndexOf(socioSeleccionado);
                        this.gimnasio.listaSocios[indice] = frmModificarSocio.DevolverSocio;
                        ClaseSerializadora<List<Socio>>.Escribir(this.gimnasio.listaSocios, nombreArchivoSocio);
                        RefrescarLista();
                        MessageBox.Show("Socio modificado", "Socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Error.No se pudo realizar la modificación del socio. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            try
            {
                if (socioSeleccionado is not null)
                {
                    socioSeleccionado.SocioActivo = false;
                    ClaseSerializadora<List<Socio>>.Escribir(this.gimnasio.listaSocios, nombreArchivoSocio);
                    RefrescarLista();
                    MessageBox.Show("Socio eliminado", "Socios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Error.No se pudo eliminar al socio. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.gimnasio.EvaluarNecesidadDeProfesores();
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
                string nombreFicha = "Ficha de "+socioSeleccionado.Nombre +" "+ socioSeleccionado.Apellido+".txt";
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

            try
            {
                if (frmAgregarModificarProfesor.DevolverProfesor is not null && resultado == DialogResult.OK)
                {
                    if (this.gimnasio.estaElProfesorEnLaLista(frmAgregarModificarProfesor.DevolverProfesor) == false)
                    {
                        this.gimnasio.listaProfesores.Add(frmAgregarModificarProfesor.DevolverProfesor);
                        GestorSQL.AltaProfesor(frmAgregarModificarProfesor.DevolverProfesor);
                        this.RefrescarLista();
                        MessageBox.Show("Profesor agregado", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else 
                    {
                        throw new PersonaException("Intento de carga duplicada de profesor");
                    }
                }
            }
            catch (PersonaException) 
            {
                MessageBox.Show("Error.El profesor ya es parte del personal del gimnasio. Verifique los datos nuevamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Error.No se pudo realizar la carga del profesor. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.gimnasio.EvaluarNecesidadDeProfesores();
        }

        /// <summary>
        /// Modifica a un profesor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarProfesor_Click(object sender, EventArgs e)
        {
            Profesor profesorSeleccionado = (Profesor)this.lstProfesores.SelectedItem;

            try
            {
                if (profesorSeleccionado is not null)
                {
                    FrmAgregarModificarProfesores frmModificarProfesor = new FrmAgregarModificarProfesores("Modificar profesor", "Modificar", profesorSeleccionado);
                    frmModificarProfesor.ShowDialog();

                    if (frmModificarProfesor.DialogResult == DialogResult.OK)
                    {
                        int indice = this.gimnasio.listaProfesores.IndexOf(profesorSeleccionado);
                        this.gimnasio.listaProfesores[indice] = frmModificarProfesor.DevolverProfesor;
                        int dniParametro = frmModificarProfesor.DevolverProfesor.Dni;
                        GestorSQL.ActualizarProfesor(frmModificarProfesor.DevolverProfesor, dniParametro);                
                        RefrescarLista();
                        MessageBox.Show("Profesor modificado", "Profesores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.No se pudo realizar la modificación del profesor. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            try
            {
                if (profesorSeleccionado is not null)
                {
                    int dniParametro = profesorSeleccionado.Dni;
                    profesorSeleccionado.ProfesorActivo = false;
                    GestorSQL.BorrarProfesor(dniParametro);
                    RefrescarLista();
                    MessageBox.Show("Profesor eliminado", "Profesor", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Error.No se pudo eliminar al profesor. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.gimnasio.EvaluarNecesidadDeProfesores();
        }

        /// <summary>
        /// Método que informa a través de un mensaje en pantalla si se necesitan contratar profesores
        /// </summary>
        /// <param name="mensajeRecordatorio"> mensaje a informar</param>
        private void InformarNecesidadDeProfesores(string mensajeRecordatorio)
        {
            if (lblRecordatorioProfesores.InvokeRequired)
            {
                Action<string> delegado = InformarNecesidadDeProfesores;
                object [] parametro= new object[] {mensajeRecordatorio};
                lblRecordatorioProfesores.Invoke(delegado, parametro);
            }
            else
            {
                Thread.Sleep(2000);
                lblRecordatorioProfesores.Visible = true;
                lblRecordatorioProfesores.Text = mensajeRecordatorio;
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

        private void btnImprimirInforme_Click(object sender, EventArgs e)
        {
            try
            {
                string contenido = this.gimnasio.InformacionGestion();
                string nombreInforme = $"Informe de gestión de fecha {DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss")}.txt";
                ClaseSerializadora<string>.EscribirEnTxt(nombreInforme, contenido);
                MessageBox.Show("Informe de gestión impreso", "Informe de gestión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception) 
            {
                MessageBox.Show("Error.No se pudo realizar la impresión del informe. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
