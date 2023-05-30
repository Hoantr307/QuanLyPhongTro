using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBaoTriDAL
    {
        DataTable GetBaoTri();

        void AddBaoTri(BaoTri BaoTri);

        void EditBaoTri(BaoTri BaoTri);

        void DeleteBaoTri(string maBaoTri);

        DataTable SearchBaoTri(string keyword);
    }
}
