using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace backend.Business
{
    public class CarroBusiness
    {
        Database.CarroDatabase database = new Database.CarroDatabase();
        Validar.ValidardorTestDrive validar = new Validar.ValidardorTestDrive();


        public List<Models.TbCarro> ListarCarros()
        {
            List<Models.TbCarro> carros=database.ListarCarros();

            if(carros.Count==0)
                throw new ArgumentException("ainda não há registros");
                
                return carros;
        }
    }
}