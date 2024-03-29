using Metanoia.Entidades;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Metanoia.Logica
{
    internal class Logica
    {

        /*Funcion para Fecha*/
        public static DateTime ObtenerFechaActual()
         {
           return DateTime.Now;
         }



        /*Funcion para Hora*/
        public static TimeSpan ObtenerHoraActual()
         {
            return DateTime.Now.TimeOfDay;
         }



        /*Funcion para el GUID (sesion)*/
        public static Guid GenerarGUID()
        {
            return Guid.NewGuid();
        }



        /*Funcion para encriptar claves utilizando Hash*/
        public static string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convierte la contraseña en un array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                // Convierte los bytes en una cadena hexadecimal
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}   
