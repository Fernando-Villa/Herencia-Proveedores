using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp6
{
    internal class pro: Item
    {
        public String Nombres;
        public String Direccion;
        public String Correo;
        public Double Telefono;

        public pro(Consola _consola, BaseDatos _objBD) : base(_consola, _objBD, "000","Empleado", "Cédula")
        {          
        }

        public pro(Consola _consola, BaseDatos _objBD, String _Codigo,
            String Nombres, String Direccion, String Correo, Double Telefono)
            :base(_consola, _objBD,_Codigo, "pro", "Cédula")
        {
            this.Nombres = Nombres;
            this.Direccion = Direccion;
            this.Correo = Correo;
            this.Telefono = Telefono;
        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD)
        {
            return new pro(_consola, _objBD);
        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD, DataRow _registro)
        {
            return new pro(_consola, _objBD, _registro["Cedula"].ToString(), 
                _registro["Nombres"].ToString(), _registro["Direccion"].ToString(), _registro["Correo"].ToString(),
                Double.Parse(_registro["Telefono"].ToString()));
        }

        public override void mostrarMembreteTabla()
        {
            consola.Escribir(40, 2, ConsoleColor.Yellow, "LISTA DE EMPLEADOS");
            consola.Escribir(5, 5, ConsoleColor.Blue, "N°"); consola.Escribir(10, 5, ConsoleColor.Blue, "Cédula");
            consola.Escribir(30, 5, ConsoleColor.Blue, "Nombres"); consola.Escribir(60, 5, ConsoleColor.Blue, "Área");
            consola.Escribir(70, 5, ConsoleColor.Blue, "Cargo"); consola.Escribir(80, 5, ConsoleColor.Blue, "Sueldo");
            consola.Marco(3, 4, 95, 15);
        }

        public override void mostrarInfoComoFila(int Num, int fila)
        {
            consola.Escribir(5, fila, ConsoleColor.White, Num.ToString()); 
            consola.Escribir(10, fila, ConsoleColor.White, Codigo);
            consola.Escribir(25, fila, ConsoleColor.White, Nombres); 
            consola.Escribir(55, fila, ConsoleColor.White, Direccion);
            consola.Escribir(70, fila, ConsoleColor.White, Correo);
            consola.Escribir(80, fila, ConsoleColor.White, Telefono.ToString("0.00"));
        }
      

        public override void mostrarInfo()
        {
            
            consola.Escribir(30, 2, ConsoleColor.Red, "INFORMACIÓN DEL EMPLEADO");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "Cédula: "); consola.Escribir(35, 5, ConsoleColor.White, Codigo);
            consola.Escribir(20, 6, ConsoleColor.Yellow, "Nombres: "); consola.Escribir(35, 6, ConsoleColor.White, Nombres);
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Area: "); consola.Escribir(35, 7, ConsoleColor.White, Direccion);
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Cargo: "); consola.Escribir(35, 8, ConsoleColor.White, Correo);
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Sueldo: "); consola.Escribir(35, 8, ConsoleColor.White, Telefono.ToString("0.00"));
        }

        public override void leerInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "NUEVO EMPLEADO");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "Cédula: ");
            consola.Escribir(20, 6, ConsoleColor.Yellow, "Nombres: ");
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Area: ");
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Cargo: ");
            consola.Escribir(20, 9, ConsoleColor.Yellow, "Sueldo: ");
            Codigo = consola.leerCadena(35, 5);
            Nombres = consola.leerCadena(35, 6);
            Direccion = consola.leerCadena(35, 7);
            Correo = consola.leerCadena(35, 8);
            Telefono = Double.Parse(consola.leerCadena(35, 9));

        }

        public override String getSQL(String TipoSQL, String CodigoABuscar = "") 
        {
            String SQL="";
            switch (TipoSQL){
                case "Insert": 
                    SQL= "Insert into TbEmpleados (Cedula, Nombres, Area, Cargo, Sueldo) values('"
                          + Codigo + "','" + Nombres + "','" + Direccion + "','" + Correo + "'," + Telefono +");";
                    break;
                case "Delete":
                    SQL = "Delete from TbEmpleados where Cedula='" + CodigoABuscar + "'";
                    break;
                case "Select":
                    if (CodigoABuscar != "")
                    {
                        SQL = "Select * from TbEmpleados where Cedula='" + CodigoABuscar + "'";
                    }
                    else
                    {
                        SQL = "Select * from TbEmpleados order by Cedula";
                    }
                    break;
              }

            return SQL;
        }



        /*   public int actualizarPrecioProductoBD(double nuevoPrecio)
           {
               String SQL = "update tbProductos set precio=" + nuevoPrecio.ToString() + " where Codigo='" + Codigo + "'";
               return objBD.ejecutarComando(SQL);
           }
        */

        /*public void actualizarPrecio()
      {
          Console.Clear();
          mostrarInfoProducto();
          consola.Escribir(20, 10, ConsoleColor.Red, "Nuevo Precio: ");
          double NuevoPrecio = consola.leerNumeroDecimal(35, 10);

          if (actualizarPrecioProductoBD(NuevoPrecio) > 0)
          {
              Precio = NuevoPrecio;
              consola.Escribir(20, 13, ConsoleColor.Blue, "Precio Actualizado! ");
          }
          else
          {
              consola.Escribir(20, 13, ConsoleColor.Blue, "Error al Actualizar precio! ");
          }

           Console.ReadLine();
      }*/

    }
}
