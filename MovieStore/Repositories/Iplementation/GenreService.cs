using MovieStore.Models.Domain;
using MovieStore.Repositories.Abstract;
using System;
using System.Linq;

namespace MovieStoreMvc.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext ctx;
        public GenreService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Genre model)
        {
            try
            {
                ctx.Genre.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return null; // Silinen tür yoksa null döndür
                ctx.Genre.Remove(data);
                ctx.SaveChanges();
                return data; // Silinen türü döndür
            }
            catch (Exception ex)
            {
                return null; // Hata durumunda null döndür
            }
        }
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var data = this.GetById(id);
        //        if (data == null)
        //            return false;
        //        ctx.Genre.Remove(data);
        //        ctx.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public Genre GetById(int id)
        {
            return ctx.Genre.Find(id);
        }

        public IQueryable<Genre> List()
        {
            var data = ctx.Genre.AsQueryable();
            return data;
        }

        public bool Update(Genre model)
        {
            try
            {
                ctx.Genre.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
