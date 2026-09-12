//INSTITUTO / UNIVERSIDAD: Centro Universitario de Tonala
//NÚMERO DE EQUIPO: Equipo #1
//INTEGRANTES:
//- Gonzalez Vega Marco Antonio
//- Landa Lopez Oscar Tadeo
//DESCRIPCIÓN: Clase de modelo para la entidad Organizacion

using System;

namespace DirectorioONG.Models
{
    public class Organizacion
    {
        private string rfc;
        private string razonSocial;
        private int aniosOperacion;
        private string rutaImagen; // Logo de la ONG
        private bool estadoActivo;

        public string Rfc
        {
            get { return rfc; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("El RFC es obligatorio."); rfc = value; }
        }
        public string RazonSocial
        {
            get { return razonSocial; }
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Nombre obligatorio."); razonSocial = value; }
        }
        public int AniosOperacion
        {
            get { return aniosOperacion; }
            set { if (value < 0) throw new ArgumentException("Los años no pueden ser negativos."); aniosOperacion = value; }
        }
        public string RutaImagen { get { return rutaImagen; } set { rutaImagen = value; } }
        public bool EstadoActivo { get { return estadoActivo; } set { estadoActivo = value; } }

        // 1. Constructor por defecto (sin parámetros)
        public Organizacion()
        {
            rfc = "XAXX010101000";
            razonSocial = "Organización Sin Nombre";
            aniosOperacion = 0;
            rutaImagen = "logo_default.png";
            estadoActivo = false;
        }

        // 2. Constructor parametrizado (asigna a través de propiedades para validar)
        public Organizacion(string rfc, string razonSocial, int aniosOperacion, string rutaImagen, bool estadoActivo)
        {
            Rfc = rfc;
            RazonSocial = razonSocial;
            AniosOperacion = aniosOperacion;
            RutaImagen = rutaImagen;
            EstadoActivo = estadoActivo;
        }

        // Versión A (Sin parámetros externos): Determina si la ONG califica para certificación institucional (requiere estar activa y al menos 3 años operando).
        public bool EsAptaParaCertificacion()
        {
            int aniosMinimosEstandar = 3;
            return EstadoActivo && AniosOperacion >= aniosMinimosEstandar;
        }

        // Versión B (Con parámetro externo): Evalúa si es apta para certificación o convocatoria exigiendo un mínimo de años personalizado.
        public bool EsAptaParaCertificacion(int aniosMinimosRequeridos)
        {
            return EstadoActivo && AniosOperacion >= aniosMinimosRequeridos;
        }

        public override string ToString()
        {
            return $"[Organización] RFC: {Rfc} | Razón Social: {RazonSocial} | Años de Operación: {AniosOperacion} | Estado: {(EstadoActivo ? "Activa" : "Inactiva")}";
        }
    }
}