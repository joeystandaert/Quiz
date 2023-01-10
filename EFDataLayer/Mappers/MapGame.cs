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
                PlayerEF player = ctx.Player.First(p => p.Id == game.Player.Id);
                if(player == null)
                {
                    player = MapPlayer.MapToDB(game.Player);
                }
                

                return new GameEF(game.Id, player, game.Score, game.Date);
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
                return new Game(game.Id, MapPlayer.MapToDomain(game.Player),game.Score,game.Date);
            }
            catch (Exception ex)
            {

                throw new MapException("MapGame - MapToDomain", ex);

            }
        }
    }
}
