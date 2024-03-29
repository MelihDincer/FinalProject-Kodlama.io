﻿using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //parametre ile gönderdiğimiz iş kurallarından başarısız olanları business'a logic'i gönder.
        public static IResult Run(params IResult[] logics) //logics => kurallar
        {
            //Bütün kuralları gez.
            foreach (var logic in logics)
            {
                //Kurala uymayan varsa,
                if (!logic.Success)
                {
                    //Uymayan kuralı döndür.
                    return logic;
                }
            }
            return null;
        }
    }
}
