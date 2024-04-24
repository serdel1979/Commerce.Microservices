using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common.Pagging
{
    public static class PaggingExtension
    {

        public static async Task<DataCollection<T>> GetPagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int take
            )
        {
            var origibalPages = page;

            page--;

            if (page > 0) page = page * take;

            var result = new DataCollection<T>
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = origibalPages,
            };

            if(result.Total > 0)
            {
                result.Page = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
}
