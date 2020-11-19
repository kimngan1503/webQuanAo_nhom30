using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LoaiDao
    {
        Model1 db = null;
        public LoaiDao()
        {
            db = new Model1();
        }
        public Loai GetByid(string tenLoai)
        {
            return db.Loais.SingleOrDefault(x => x.TenLoai == tenLoai);
        }
        public Loai ViewDetail(int id)
        {
            return db.Loais.Find(id);
        }
        public int Insert(Loai enity)
        {
            db.Loais.Add(enity);
            db.SaveChanges();
            return enity.IDloai;
        }
        public bool Update(Loai enity)
        {
            try
            {
                var loai = db.Loais.Find(enity.IDdanhmuc);
                loai.TenLoai = enity.TenLoai;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<Loai> ListAllPaging(int page, int pageSize)
        {
            return db.Loais.OrderByDescending(x => x.IDloai).ToPagedList(page, pageSize);
        }
        

        public List<Loai> ListAll()
        {
            return db.Loais.OrderBy(x => x.IDloai).ToList();
        }
    }
}
