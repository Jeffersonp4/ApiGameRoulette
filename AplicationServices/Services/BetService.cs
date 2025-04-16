using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicationServices.DTOs;
using DataAccessLayer.Helpers;
using RepositoryLayer.EntityFramework.Services;

namespace AplicationServices.Services
{
    public class BetService: IBet
    {
        
        private readonly IUserRepository _userRepository;

        public BetService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public RouletteDto CreateRandomNumberColor()
        {
            var random = new Random();

            int number = random.Next(0, 37); // aleatorio entre 0 al 36

            string[] colors = { "rojo", "Negro" };

            string randomColor = colors[random.Next(colors.Length)]; // aleatorio entre rojo y negro

            var result = new RouletteDto
            {
                Number = number,
                Color = randomColor
            };

            return result;


        }

        public  BetDto MakeBet(BetDto userBet)
        {

            decimal AmountWin = 0;
            var BetDto = new BetDto
            {
                Name = userBet.Name,
                Color = userBet.Color,
                Number = userBet.Number,
                BetType = userBet.BetType,
                BetValue = userBet.BetValue,
                BetAmount = userBet.BetAmount,
                Balance = userBet.Balance,
                AmountWin = userBet.AmountWin,

            };

            if (userBet.BetAmount <= 0)
            {
                throw new AccessViolationException("El monto Apostado debe ser mayor a cero");
            }

            string combination = CreateCombinationValue(userBet.BetType,BetDto.Color,BetDto.Number);
            bool win = EvaluateBet(userBet.BetValue, combination);
  

            if (!win)
            {
                BetDto.Balance = BetDto.Balance - userBet.BetAmount;
                BetDto.AmountWin = userBet.AmountWin;
                BetDto.Result = win;
            }
            else 
            {
                AmountWin = CalculateAmountWin(userBet.BetType, userBet.BetAmount);
                BetDto.Balance = BetDto.Balance + AmountWin;
                BetDto.AmountWin = AmountWin;
                BetDto.Result = win;
            }

            return  BetDto;
        }

        private bool EvaluateBet(string betUserValue, string rouletteValue) 
        {
            return betUserValue.Trim().ToLower() == rouletteValue.Trim().ToLower();
        }

        private string CreateCombinationValue(BetTypeEnum betType,  string color, int number)
        {
            string combination = string.Empty;
            switch (betType)
            {
                case BetTypeEnum.Color:
                    combination = color;
                    break;

                case BetTypeEnum.PairOddColor:
                    string parity = RouletteHelper.Getparity(number);
                    combination = $"{parity}--{color}";
                    break;

                case BetTypeEnum.NumberColor:
                    combination = $"{number}--{color}";
                    break ;

                default:
                    throw new ApplicationException("Esta Apuesta no es valida");
            }

            return combination;

        }

        private decimal CalculateAmountWin(BetTypeEnum betType, decimal amount)
        {
            
            
                switch (betType)
                {
                    case BetTypeEnum.Color:
                        return amount * 0.5m;
                    case BetTypeEnum.PairOddColor:
                        return amount;
                    case BetTypeEnum.NumberColor:
                        return amount * 3;

                    default: 
                        throw new ApplicationException("Esta Apuesta no es valida");
                }

        }

    }
}
