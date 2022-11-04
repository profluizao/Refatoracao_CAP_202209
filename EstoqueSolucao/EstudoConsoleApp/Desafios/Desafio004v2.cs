﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 004 - Crie um programa que leia um número e mostre o seu dobro, seu triplo e sua raiz
    /// quadrada.
    /// </summary>
    public static class Desafio004v2
    {
        public static void Executar()
        {
            double numero;
            Console.WriteLine("Informe qualquer número: ");
            if (Double.TryParse(Console.ReadLine(), out numero) == false)
            {
                Console.WriteLine("Favor informar apenas números.");
                return;
            }

            double dobro = numero * 2;
            double triplo = numero * 3;
            double raiz = Math.Sqrt(numero);
            Console.WriteLine("Para o número {0}:", numero);
            Console.WriteLine("\tO dobro do número informado é {0}", dobro);
            Console.WriteLine("\tO triplo do número informado é {0}", triplo);
            Console.WriteLine("\tA raíz quadrada do número informado é {0}", raiz);
        }
    }
}
