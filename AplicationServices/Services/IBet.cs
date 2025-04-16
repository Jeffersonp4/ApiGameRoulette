using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicationServices.DTOs;

namespace AplicationServices.Services
{
    public interface IBet
    {
        public BetDto MakeBet(BetDto result);
        public RouletteDto CreateRandomNumberColor();
    }
}
