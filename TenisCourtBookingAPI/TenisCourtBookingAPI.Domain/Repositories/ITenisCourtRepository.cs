using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenisCourtBookingAPP.Domain.Entities;

namespace TenisCourtBookingAPP.Domain.Repositories
{
    public interface ITenisCourtRepository
    {
        void AddTenisCourt(TenisCourt tenisCourt);
        TenisCourt UpdateTenisCourt(TenisCourt tenisCourt);
        bool DeleteTenisCourt(int id);
        List<TenisCourt> ViewAllTenisCourt();
        TenisCourt GetTenisCourt(int id);
    }
}
