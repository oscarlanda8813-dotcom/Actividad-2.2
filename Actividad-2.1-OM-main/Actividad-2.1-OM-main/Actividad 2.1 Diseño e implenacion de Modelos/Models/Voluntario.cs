//INSTITUTO / UNIVERSIDAD: Centro Universitario de Tonala
//NÚMERO DE EQUIPO: Equipo #1
//INTEGRANTES:
//- Gonzalez Vega Marco Antonio
//- Landa Lopez Oscar Tadeo
//DESCRIPCIÓN: Clase de modelo para la entidad Voluntario

using System;

namespace DirectorioONG.Models
{
    public class Voluntario
    {
        private string idVoluntario;
        private string nombre;
        private int horasAportadas;
        private string rutaImagen;
        private bool estadoActivo;

        public string IdVoluntario
        {
            get { return idVoluntario; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("ID requerido."); idVoluntario = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { if (value.Length < 3) throw new ArgumentException("Nombre muy corto."); nombre = value; }
        }
        public int HorasAportadas
        {
            get { return horasAportadas; }
            set { if (value < 0) throw new ArgumentException("Horas no pueden ser negativas."); horasAportadas = value; }
        }
        public string RutaImagen { get { return rutaImagen; } set { rutaImagen = value; } }
        public bool EstadoActivo { get { return estadoActivo; } set { estadoActivo = value; } }

        public Voluntario()
        {
            idVoluntario = "VOL-000";
            nombre = "Sin Nombre";
            horasAportadas = 0;
            rutaImagen = "default.png";
            estadoActivo = false;
        }

        public Voluntario(string idVoluntario, string nombre, int horasAportadas, string rutaImagen, bool estadoActivo)
        {
            IdVoluntario = idVoluntario;
            Nombre = nombre;
            HorasAportadas = horasAportadas;
            RutaImagen = rutaImagen;
            EstadoActivo = estadoActivo;
        }

        public bool ElegibleParaReconocimiento()
        {
            return EstadoActivo && HorasAportadas >= 50;
        }

        public bool ElegibleParaReconocimiento(int horasMinimasRequeridas)
        {
            return EstadoActivo && HorasAportadas >= horasMinimasRequeridas;
        }

        public override string ToString()
        {
            return $"[Voluntario] ID: {IdVoluntario} | Nombre: {Nombre} | Horas: {HorasAportadas} | Estado: {(EstadoActivo ? "Activo" : "Inactivo")}";
        }
    }
}