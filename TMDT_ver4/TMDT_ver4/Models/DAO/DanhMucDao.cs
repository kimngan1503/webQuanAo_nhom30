using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models.DAO
{
    public class DanhMucDao
    {
        Model1 db = null;
        public DanhMucDao()
        {
            db = new Model1();
        }
        public DanhMuc GetByid(string tenDanhMuc)
        {
            return db.DanhMucs.SingleOrDefault(x => x.TenDanhMuc == tenDanhMuc);
        }
        public DanhMuc ViewDetail (int id)
        {
            return db.DanhMucs.Find(id);
        }
        public int Insert(DanhMuc enity)
        {
            db.DanhMucs.Add(enity);
            db.SaveChanges();
            return enity.IDdanhmuc;
        }
        public bool Update(DanhMuc enity)
        {
            try
            {
                var danhmuc = db.DanhMucs.Find(enity.IDdanhmuc);
                danhmuc.TenDanhMuc = enity.TenDanhMuc;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public IEnumerable<DanhMuc> ListAllPaging(int page, int pageSize)
        {
            return db.DanhMucs.OrderByDescending(x => x.IDdanhmuc).ToPagedList(page, pageSize);
        }

        public List<DanhMuc> ListAll()
        {
            return db.DanhMucs.OrderBy(x => x.IDdanhmuc).ToList();
        }
      
    }
}
