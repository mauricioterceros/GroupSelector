using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.Database.Models;

namespace APITEST.Database
{
    public class StudentTableDB : IStudentTableDB
    {
        public List<Student> GetAll()
        {
            return new List<Student>()
            {
                new Student() { Name="CARLOS GABRIEL  ACOSTA CLAROS   ", Email="gabrielacoata@gmail.com"},
                new Student() { Name="CARLA ANDREA    BARRIENTOS MUÑOZ    ", Email="carla.andrea.cbm@gmail.com"},
                new Student() { Name="PEDRO ANDRES    BRAñEZ CADIMA   ", Email="pedrobran8@gmail.com "},
                new Student() { Name="CESAR ALEJANDRO BUENO AZURDUY   ", Email="alebuenoaz@gmail.com"},
                new Student() { Name="VANESSA GABRIELA    BUSTILLOS NAJERA    ", Email="vanebustillos1@gmail.com"},
                new Student() { Name="FROILAN JOSUE   CARDOZO ZAMBRANA    ", Email="jsosueczf@gmail.com"},
                new Student() { Name="RICARDO ALEXANDER   FERNANDEZ BENAVIDES ", Email="humanoastuto321@gmail.com"},
                new Student() { Name="ANDRES  GAMBOA BALDI    ", Email="andresgamboabaldi@gmail.com"},
                new Student() { Name="JUAN DIEGO  GARCIA VARGAS   ", Email="juandigv69@gmail.com"},
                new Student() { Name="PEDRO GERARDO   GONZALEZ POZO   ", Email="ggonzalezpozopedro@gmail.com"},
                new Student() { Name="RODRIGO NICOLAS HEREDIA ALCOCER ", Email="rodrigoh1205@gmail.com"},
                new Student() { Name="MATEO   LOPEZ LEDEZMA   ", Email="lm67427572@gmail.com"},
                new Student() { Name="RUBEN ALEJANDRO MALDONADO FUENTES   ", Email="romancalle14@gmail.com"},
                new Student() { Name="ANA PAOLA   MONTERO CASSAB  ", Email="anapao.montero@gmail.com"},
                new Student() { Name="BRAMI ATMANI    PRUDENCIO RODRIGUEZ ", Email="bramopit@gmail.com"},
                new Student() { Name="ALEJANDRA DAYANA    QUELALI CALCINA ", Email="alejandra.day.123@gmail.com"},
                new Student() { Name="PABLO   RIVAS   ", Email="pabloperedo04@gmail.com"},
                new Student() { Name="MELISA  ROJAS SORIA ", Email="melisa.rs.1990@gmail.com"},
                new Student() { Name="DIEGO ALEJANDRO ROSAZZA MERIDA  ", Email="diegorosazza@gmail.com"},
                new Student() { Name="STEFANO DANIEL  SOSSI ROJAS ", Email="tenosossi2012@gmail.com "},
                new Student() { Name="VINCENT ALEJANDRO   VALENZUELA ISPAN    ", Email="note234vnt@gmail.com"},
                new Student() { Name="ANDREA NATALIA  VILLARROEL CAMACHO  ", Email="anditavillarroel99@gmail.com"}
            };
        }
    }
}
