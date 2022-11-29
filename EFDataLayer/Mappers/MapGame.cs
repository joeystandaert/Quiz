using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using EFDataLayer.Exceptions;
using EFDataLayer.Models;

namespace EFDataLayer.Mappers
{
    public interface MapGame
    {
        public static GameEF MapToDB(Game game, QuizContext ctx)
        {
            try
            {
                PlayerEF player = ctx.Player.Find(game.Player.Id);
                if(player == null)
                {
                    player = MapPlayer.MapToDB(game.Player);
                }
                List<QuestionEF> questions = ctx.Question.Where(q => game.Questions.Select(q => q.Id).Contains(q.Id)).ToList();

                return new GameEF(game.Id, player, questions, game.Score, game.Date);
            }
            catch (Exception ex)
            {

                throw new MapException("MapGame - MapToDB",ex);
            }
        }

        public static Game MapToDomain(GameEF game)
        {
            try
            {
                return new Game(game.Id, MapPlayer.MapToDomain(game.Player),game.Questions.Select(q => MapQuestion.MapToDomain(q)).ToList(),game.Score,game.Date);
            }
            catch (Exception ex)
            {

                throw new MapException("MapGame - MapToDomain", ex);

            }
        }
    }
}
