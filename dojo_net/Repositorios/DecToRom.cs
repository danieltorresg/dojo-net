using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dojo_net.Repositorios
{
    public class DecToRom 
    {
        public Numero decimalRomano(Numero number)
        {
            number.numRomano = decimalToRoman(number.numDecimal);

            return number;

        }

        public Numero[] listaNumeros()
        {
            Numero[] numeros = new Numero[500];
            Numero number;
            for (int i = 1; i <= 500; i++)
            {
                number = new Numero { numDecimal = i };
                number.numRomano = decimalToRoman(number.numDecimal);
                numeros[i-1] = number;
            }

            return numeros;

        }


        public static string decimalToRoman(int decimalValueParam)
        {
            int decimalValue = decimalValueParam;
            int[] numbers = new int[] { 1, 5, 10, 50, 100, 500, 1000 };
            //var number = new Numero();
            string[] romans = new string[] { "I", "V", "X", "L", "C", "D", "M" };
            Stack<string> totalRoman = new Stack<string>();
            int currentNumber = 0;
            string letter = "";
            string value = "";
            int position = 0;
            string aux = "";

            for (int i = 6; i >= 0; i--)
            {
                currentNumber = numbers[i];
                letter = romans[i];
                if (decimalValue >= currentNumber)
                {
                    int floor = (decimalValue / currentNumber);
                    decimalValue -= floor * currentNumber;
                    if (floor < 4)
                    {
                        while (floor > 0)
                        {
                            totalRoman.Push(letter);
                            floor--;
                        }
                    }
                    else
                    {
                        value = totalRoman.Pop();
                        if (value != "")
                        {
                            position = Array.IndexOf(romans, value) + 1;
                        }
                        else
                        {
                            position = i + 1;
                        }
                        if (romans[position] != null)
                        {
                            aux = letter + romans[position];

                        }
                        else
                        {
                            aux = "M";
                        }
                        totalRoman.Push(aux);
                    }
                }
                else
                {
                    totalRoman.Push("");
                }
            }
            string[] total = totalRoman.ToArray<string>();
            Array.Reverse(total);
            return string.Join("", total);

        }

        public Numero ObtenerNumero(int id)
        {
            Numero number;
            if (id>0 && id<=500)
            {
                var roman = decimalToRoman(id);
                number = new Numero { numDecimal = id, numRomano = roman };
            }
            else
            {
                number = null;
            }

            return number;
        }


        /*public static List<Numero> _listaNumeros = new List<Numero>()
        {
            new Cliente() { Id = 1, Nombre = "Cliente 1" , Apellido = "Apellido 1" },
            new Cliente() { Id = 2, Nombre = "Cliente 2" , Apellido = "Apellido 2" },
            new Cliente() { Id = 3, Nombre = "Cliente 3" , Apellido = "Apellido 3" }
        };

        public IEnumerable<Cliente> ObtenerClientes()
        {
            return _listaClientes;
        }

        public Cliente ObtenerCliente(int id)
        {
            var cliente = _listaClientes.Where(cli => cli.Id == id);

            return cliente.FirstOrDefault();
        }

        public void Agregar(Cliente nuevoCliente)
        {
            _listaClientes.Add(nuevoCliente);
        }*/
    }
}
