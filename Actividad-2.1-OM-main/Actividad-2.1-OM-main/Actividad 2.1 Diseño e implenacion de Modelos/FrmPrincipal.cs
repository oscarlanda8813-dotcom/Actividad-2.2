//INSTITUTO / UNIVERSIDAD: Centro Universitario de Tonala
//NÚMERO DE EQUIPO: Equipo #1
//INTEGRANTES:
//- Gonzalez Vega Marco Antonio
//- Landa Lopez Oscar Tadeo

using System;
using System.Windows.Forms;
using DirectorioONG.Models; // Asegura la referencia a tus modelos

namespace Actividad_2._1_Diseño_e_implenacion_de_Modelos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        // 1. Evento Botón Beneficiario
        private void btnProcesarBeneficiario_Click(object sender, EventArgs e)
        {
            try
            {
                string curp = txtCurp.Text.Trim(); //[cite: 1]
                string nombre = txtNombreBeneficiario.Text.Trim(); //[cite: 1]
                int edad = int.Parse(txtEdad.Text.Trim()); //[cite: 1]
                string ruta = txtRutaImagenBeneficiario.Text.Trim(); //[cite: 1]
                bool estado = chkEstadoBeneficiario.Checked; //[cite: 1]

                // Instancia del modelo parametrizado
                Beneficiario obj = new Beneficiario(curp, nombre, edad, ruta, estado); //[cite: 1]

                // Ejecución de métodos con sobrecarga
                bool elegibleEstandar = obj.ElegibleParaApoyo(); //[cite: 1]
                bool elegibleProgramaEspecial = obj.ElegibleParaApoyo(60); //[cite: 1]

                txtResultadoBeneficiario.Text = $"{obj}\r\n" + //[cite: 1]
                    $"-> Elegible General: {(elegibleEstandar ? "SÍ" : "NO")}\r\n" +
                    $"-> Elegible Programa Adulto Mayor (60+): {(elegibleProgramaEspecial ? "SÍ" : "NO")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Beneficiario: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 2. Evento Botón Categoría
        private void btnProcesarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIdCategoria.Text.Trim()); //[cite: 2]
                string nombre = txtNombreCategoria.Text.Trim(); //[cite: 2]
                string desc = txtDescripcionCategoria.Text.Trim(); //[cite: 2]
                string ruta = txtRutaImagenCategoria.Text.Trim(); //[cite: 2]
                bool estado = chkEstadoCategoria.Checked; //[cite: 2]

                Categoria obj = new Categoria(id, nombre, desc, ruta, estado); //[cite: 2]

                string etiquetaNormal = obj.ObtenerEtiqueta(); //[cite: 2]
                string etiquetaEspecial = obj.ObtenerEtiqueta("ODS-2026"); //[cite: 2]

                txtResultadoCategoria.Text = $"{obj}\r\n" + //[cite: 2]
                    $"-> Etiqueta Normal: {etiquetaNormal}\r\n" +
                    $"-> Etiqueta Especial: {etiquetaEspecial}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Categoría: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 3. Evento Botón Donación
        private void btnProcesarDonacion_Click(object sender, EventArgs e)
        {
            try
            {
                string folio = txtFolioDonacion.Text.Trim(); //[cite: 3]
                decimal monto = decimal.Parse(txtMonto.Text.Trim()); //[cite: 3]
                DateTime fecha = dtpFechaDonacion.Value; //[cite: 3]
                string ruta = txtRutaImagenDonacion.Text.Trim(); //[cite: 3]
                bool estado = chkEstadoDonacion.Checked; //[cite: 3]

                Donacion obj = new Donacion(folio, monto, fecha, ruta, estado); //[cite: 3]

                decimal netoEstandar = obj.CalcularMontoNeto(); //[cite: 3]
                decimal netoPasarela = obj.CalcularMontoNeto(10m); //[cite: 3]

                txtResultadoDonacion.Text = $"{obj}\r\n" + //[cite: 3]
                    $"-> Neto (Comisión estándar 5%): {netoEstandar:C2}\r\n" +
                    $"-> Neto (Comisión pasarela 10%): {netoPasarela:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Donación: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 4. Evento Botón Donante
        private void btnProcesarDonante_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtIdDonante.Text.Trim(); //[cite: 4]
                string razon = txtRazonSocial.Text.Trim(); //[cite: 4]
                string tipo = cmbTipoDonante.SelectedItem?.ToString() ?? "Persona"; //[cite: 4]
                string ruta = txtRutaImagenDonante.Text.Trim(); //[cite: 4]
                bool estado = chkEstadoDonante.Checked; //[cite: 4]

                Donante obj = new Donante(id, razon, tipo, ruta, estado); //[cite: 4]

                string constanciaBasica = obj.GenerarConstanciaFiscal(); //[cite: 4]
                string constanciaSat = obj.GenerarConstanciaFiscal("SAT-9988776655"); //[cite: 4]

                txtResultadoDonante.Text = $"{obj}\r\n" + //[cite: 4]
                    $"-> {constanciaBasica}\r\n" +
                    $"-> {constanciaSat}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Donante: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 5. Evento Botón Evento
        private void btnProcesarEvento_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtIdEvento.Text.Trim(); //[cite: 8]
                string titulo = txtTituloEvento.Text.Trim(); //[cite: 8]
                DateTime fecha = dtpFechaEvento.Value; //[cite: 8]
                string ruta = txtRutaImagenEvento.Text.Trim(); //[cite: 8]
                bool estado = chkEstadoEvento.Checked; //[cite: 8]

                Evento obj = new Evento(id, titulo, fecha, ruta, estado); //[cite: 8]

                int diasHoy = obj.CalcularDiasRestantes(); //[cite: 8]
                int diasReferencia = obj.CalcularDiasRestantes(DateTime.Now.AddDays(2)); //[cite: 8]

                txtResultadoEvento.Text = $"{obj}\r\n" + //[cite: 8]
                    $"-> Días restantes desde hoy: {diasHoy} día(s)\r\n" +
                    $"-> Días restantes desde fecha de corte: {diasReferencia} día(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Evento: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 6. Evento Botón Organización
        private void btnProcesarOrg_Click(object sender, EventArgs e)
        {
            try
            {
                string rfc = txtRfc.Text.Trim(); //[cite: 9]
                string razon = txtRazonSocialOrg.Text.Trim(); //[cite: 9]
                int anios = int.Parse(txtAniosOperacion.Text.Trim()); //[cite: 9]
                string ruta = txtRutaImagenOrg.Text.Trim(); //[cite: 9]
                bool estado = chkEstadoOrg.Checked; //[cite: 9]

                Organizacion obj = new Organizacion(rfc, razon, anios, ruta, estado); //[cite: 9]

                bool aptaEstandar = obj.EsAptaParaCertificacion(); //[cite: 9]
                bool aptaExigente = obj.EsAptaParaCertificacion(5); //[cite: 9]

                txtResultadoOrg.Text = $"{obj}\r\n" + //[cite: 9]
                    $"-> Apta Certificación Estándar (3+ años): {(aptaEstandar ? "SÍ" : "NO")}\r\n" +
                    $"-> Apta Convocatoria Especial (5+ años): {(aptaExigente ? "SÍ" : "NO")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Organización: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 7. Evento Botón Programa Social
        private void btnProcesarPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtIdPrograma.Text.Trim(); //[cite: 5]
                string nombre = txtNombrePrograma.Text.Trim(); //[cite: 5]
                int capacidad = int.Parse(txtCapacidadPersonas.Text.Trim()); //[cite: 5]
                string ruta = txtRutaImagenPrograma.Text.Trim(); //[cite: 5]
                bool estado = chkEstadoPrograma.Checked; //[cite: 5]

                ProgramaSocial obj = new ProgramaSocial(id, nombre, capacidad, ruta, estado); //[cite: 5]

                int cupoInicial = obj.CalcularCupoDisponible(); //[cite: 5]
                int cupoConInscritos = obj.CalcularCupoDisponible(15); //[cite: 5]

                txtResultadoPrograma.Text = $"{obj}\r\n" + //[cite: 5]
                    $"-> Lugares totales iniciales: {cupoInicial}\r\n" +
                    $"-> Lugares restantes (con 15 inscritos): {cupoConInscritos}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Programa Social: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 8. Evento Botón Testimonio
        private void btnProcesarTestimonio_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIdTestimonio.Text.Trim()); //[cite: 6]
                string autor = txtAutorTestimonio.Text.Trim(); //[cite: 6]
                int calificacion = int.Parse(cmbCalificacion.SelectedItem?.ToString() ?? "5"); //[cite: 6]
                string ruta = txtRutaImagenTestimonio.Text.Trim(); //[cite: 6]
                bool estado = chkEstadoTestimonio.Checked; //[cite: 6]

                Testimonio obj = new Testimonio(id, autor, calificacion, ruta, estado); //[cite: 6]

                string estrellas = obj.ObtenerCalificacionEstrellas(); //[cite: 6]
                bool esDestacado = obj.CumpleCriterioDestacado(4); //[cite: 6]

                txtResultadoTestimonio.Text = $"{obj}\r\n" + //[cite: 6]
                    $"-> Valoración gráfica: {estrellas}\r\n" +
                    $"-> ¿Apto para Portada (Mínimo 4 estrellas)?: {(esDestacado ? "SÍ" : "NO")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Testimonio: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 9. Evento Botón Voluntario
        private void btnProcesarVoluntario_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtIdVoluntario.Text.Trim(); //[cite: 7]
                string nombre = txtNombreVoluntario.Text.Trim(); //[cite: 7]
                int horas = int.Parse(txtHorasAportadas.Text.Trim()); //[cite: 7]
                string ruta = txtRutaImagenVoluntario.Text.Trim(); //[cite: 7]
                bool estado = chkEstadoVoluntario.Checked; //[cite: 7]

                Voluntario obj = new Voluntario(id, nombre, horas, ruta, estado); //[cite: 7]

                bool reconEstandar = obj.ElegibleParaReconocimiento(); //[cite: 7]
                bool reconInsigniaOro = obj.ElegibleParaReconocimiento(100); //[cite: 7]

                txtResultadoVoluntario.Text = $"{obj}\r\n" + //[cite: 7]
                    $"-> Reconocimiento Estándar (50+ hrs): {(reconEstandar ? "SÍ" : "NO")}\r\n" +
                    $"-> Insignia de Oro (100+ hrs): {(reconInsigniaOro ? "SÍ" : "NO")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Voluntario: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 10. Evento Botón Administrador
        private void btnProcesarAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtIdAdmin.Text.Trim(); //[cite: 7]
                string nombre = txtNombreAdmin.Text.Trim(); //[cite: 7]
                string correo = txtCorreoAdmin.Text.Trim(); //[cite: 7]
                string ruta = txtRutaImagenAdmin.Text.Trim(); //[cite: 7]
                bool estado = chkEstadoAdmin.Checked; //[cite: 7]

                Administrador obj = new Administrador(id, nombre, correo, ruta, estado); //[cite: 7]

                bool accesoBasico = obj.ValidarAcceso(); //[cite: 7]
                bool accesoClave = obj.ValidarAcceso("ONGAdmin2026"); //[cite: 7]

                txtResultadoAdmin.Text = $"{obj}\r\n" + //[cite: 7]
                    $"-> Estado de Cuenta Activo: {(accesoBasico ? "SÍ" : "NO")}\r\n" +
                    $"-> Validación de Clave Maestra: {(accesoClave ? "ACCESO CONCEDIDO" : "DENEGADO")}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Administrador: {ex.Message}", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}