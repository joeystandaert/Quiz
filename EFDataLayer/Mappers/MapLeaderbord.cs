using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using EFDataLayer.Exceptions;
using EFDataLayer.Models;

namespace EFDataLayer.Mappers
{
    public interface MapLeaderbord
    {
 
        public static List<LeaderbordStat> MapToDomain(List<GameEF> games)
        {
            try
            {
                var list = new List<LeaderbordStat>();
                foreach (GameEF item in games)
                {
                    var stat = list.FirstOrDefault(ls => ls.Player.Id == item.Player.Id);
                    if ( stat != null)
                    {
                        //update leaderbordstat
                        stat.GamesPlayed++;
                        if (stat.MaxScore < item.Score) stat.MaxScore = item.Score;
                    }
                    else
                    {
                        //add leaderbordstat
                        list.Add(new LeaderbordStat(MapPlayer.MapToDomain(item.Player), 1, item.Score));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {

                throw new MapException("MapLeaderbord - MapToDomain", ex);

            }
        }
    }
}
