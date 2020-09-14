using AdSanare.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdSanare.MVC.Helper
{
    public class ELog
    {
        private readonly AdSanareDbContext _context;

        public ELog(AdSanareDbContext context)
        {
            _context = context;
        }

        //public static void save(object obj, Exception ex)
        //{
        //    string fecha = System.DateTime.Now.ToString("yyyyMMdd");
        //    string hora = System.DateTime.Now.ToString("HH:mm:ss");
        //    string path = _context
        //    //string path = HttpContext.Current.Request.MapPath("~/log/" + fecha + ".txt");

        //    StreamWriter sw = new StreamWriter(path, true);

        //    StackTrace stacktrace = new StackTrace();
        //    sw.WriteLine(obj.GetType().FullName + " " + hora);
        //    sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
        //    sw.WriteLine("");

        //    sw.Flush();
        //    sw.Close();
        //}
    }
}
