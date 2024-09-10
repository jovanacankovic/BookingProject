using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Utils
{
    public enum HotelFilterCriteria
    {
        None, 
        ID,
        NAME,
        ESTABLISHMENT_YEAR,
        STARS,
        APARTMENT
    }
}
