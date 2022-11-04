﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dominio.AtacadoFrota
{
    public class Motocicleta : BasePesoCarga
    {
        public Motocicleta() : base()
        { }

        public Motocicleta(bool ativo, int codigo, DateTime dataInclusao, string chassi, string cor, 
            string marca, string modelo, string placa, double pesoBruto, double pesoLiquido, double pesoTotal) 
            : base(ativo, codigo, dataInclusao, chassi, cor, marca, modelo, placa, pesoBruto, pesoLiquido, pesoTotal)
        { }
    }
}
