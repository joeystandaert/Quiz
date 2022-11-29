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
    public interface MapPlayer
    {
        public static PlayerEF MapToDB(Player player)
        {
			try
			{
				return new PlayerEF(player.Id, player.Name);
			}
			catch (Exception ex)
			{

				throw new MapException("MapPlayer - MapToDB",ex);
			}
        }

		public static Player MapToDomain(PlayerEF player)
		{
			try
			{
				return new Player(player.Id, player.Name);
			}
			catch (Exception ex)
			{
				throw new MapException("MapPlayer - MapToDomain", ex);
			}
		}
    }
}
