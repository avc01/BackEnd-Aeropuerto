﻿using System;

namespace BackEnd_Aeropuerto.Dtos
{
    public class ErrorReadDto
    {
        public int ErrorId { get; set; }

        public DateTime FechaHora { get; set; }

        public int Numero { get; set; }

        public string Mensaje { get; set; }
    }
}
