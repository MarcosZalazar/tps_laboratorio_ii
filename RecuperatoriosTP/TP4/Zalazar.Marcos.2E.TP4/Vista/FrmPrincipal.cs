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
            nombreArchivoEgreso = "listaEgresos.json";
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            this.gimnasio = new Gimnasio("Espartanos");
            this.primerArchivoSocio=AppDomain.CurrentDomain.BaseDirectory + "MockSocio.xml";
            this.gimnasio.NotificacionEnviada += InformarNecesidadDeProfesores;
            this.btnLimpiarInforme.Enabled = false;
            this.btnImprimirInforme.Enabled = false;
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
        /// Imprime la ficha del socio seleccionado
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
        /// Carga los ingresos obtenidos por las cuotas
        /// </summary>
        public void CargarIngresosPorCuotas()
        {
            foreach (Socio socio in this.gimnasio.listaSocios)
            {
                if (socio.SocioActivo == true)
                {
                    if (socio.Membresia == ECampos.EMembresia.Smart)
                    {
                        Ingreso ingreso = new Ingreso($"Cuota de {socio.Nombre}", 1000);
                        this.gimnasio.PeriodoComercial.AgregarIngreso(this.gimnasio.PeriodoComercial, ingreso);
                    }
                    else
                    {
                        Ingreso ingreso = new Ingreso($"Cuota de {socio.Nombre}", 2000);
                        this.gimnasio.PeriodoComercial.AgregarIngreso(this.gimnasio.PeriodoComercial, ingreso);
                    }
                }
            }
        }

        /// <summary>
        /// Carga los egresos por salarios de los profesores
        /// </summary>
        public void CargarEgresosPorSalarios()
        {
            foreach (Profesor profesor in this.gimnasio.listaProfesores)
            {
                if (profesor.ProfesorActivo == true)
                {
                    Egreso egreso = new Egreso($"Salario del profesor {profesor.Nombre}", (int)profesor.Salario);
                    this.gimnasio.PeriodoComercial.AgregarEgreso(this.gimnasio.PeriodoComercial, egreso);
                    ClaseSerializadoraJson<List<Egreso>>.Escribir(this.gimnasio.PeriodoComercial.Egresos, nombreArchivoEgreso);
                }
            }
        }

        /// <summary>
        /// Genera un informe de gestion del gimnasio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarInformeGestion_Click(object sender, EventArgs e)
        {
            try
            {
                CargarIngresosPorCuotas();
                CargarEgresosPorSalarios();
                ClaseSerializadoraJson<List<Egreso>>.Escribir(this.gimnasio.PeriodoComercial.Egresos, nombreArchivoEgreso);
                this.rtbGestion.Text = this.gimnasio.InformacionGestion();
                MessageBox.Show("Se ha generado el informe en formato json. Para conservarlo, haga una copia del archivo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.btnImportarEgresos.Enabled = false;
                this.btnRegistrarEgresos.Enabled = false;
                this.btnGenerarInformeGestion.Enabled = false;
                this.btnLimpiarInforme.Enabled = true;
                this.btnImprimirInforme.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error.No se pudo generar el informe. Intente nuevamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Limpia el informe de gestion de la pantalla y de los archivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiarInforme_Click(object sender, EventArgs e)
        {
            try 
            {
                this.rtbGestion.Text = "";
                this.gimnasio.PeriodoComercial.Egresos.Clear();
                this.gimnasio.PeriodoComercial.Ingresos.Clear();
                ClaseSerializadoraJson<List<Egreso>>.Escribir(this.gimnasio.PeriodoComercial.Egresos, nombreArchivoEgreso);

                MessageBox.Show("Se ha borrado el informe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.btnImportarEgresos.Enabled = true;
                this.btnRegistrarEgresos.Enabled = true;
                this.btnGenerarInformeGestion.Enabled = true;
                this.btnLimpiarInforme.Enabled = false;
                this.btnImprimirInforme.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error.No se pudo borrar el informe. Intente nuevamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

            try
            {
                if (frmAgregarEgreso.DevolverEgreso is not null && resultado == DialogResult.OK)
                {
                    this.gimnasio.PeriodoComercial.AgregarEgreso(this.gimnasio.PeriodoComercial, frmAgregarEgreso.DevolverEgreso);
                    MessageBox.Show("Egreso agregado", "Egresos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Error.No se pudo registrar los egresos. Intente nuevamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.btnImportarEgresos.Enabled = false;
        }

        /// <summary>
        /// Importa un archivo de egresos en formato Json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportarEgresos_Click(object sender, EventArgs e)
        {
            try
            {
                this.gimnasio.PeriodoComercial.Egresos = ClaseSerializadoraJson<List<Egreso>>.Leer("ImportadorEgresos.json");
                MessageBox.Show("Egreso importado con éxito", "Egresos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Error.No se pudo importar los egresos. Revise el archivo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally 
            {
                this.btnImportarEgresos.Enabled = false;
            }
        }

        /// <summary>
        /// Imprime el informe de gestión en un archivo txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimirInforme_Click(object sender, EventArgs e)
        {
            try
            {
                Task tareaDeImpresion = Task.Run(() =>
                {
                    string contenido = this.gimnasio.InformacionGestion();
                    string nombreInforme = $"Informe de gestión de fecha {DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss")}.txt";
                    MessageBox.Show("Esta tarea podia demorar algunos segundos.Aguarde mientras se imprime el informe", "Informe de gestión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Thread.Sleep(4000);
                    ClaseSerializadora<string>.EscribirEnTxt(nombreInforme, contenido);
                    MessageBox.Show("Informe de gestión impreso", "Informe de gestión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                });
            }
            catch (Exception) 
            {
                MessageBox.Show("Error.No se pudo realizar la impresión del informe. Intente nuevamente ", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.btnImprimirInforme.Enabled= false;
        }
    }
}
