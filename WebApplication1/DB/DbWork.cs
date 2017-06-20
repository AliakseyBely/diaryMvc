using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DB
{
    public class DbWork
    {
        
        public void createMess()
        {
            var dbContext = new DiaryDb();

        }

        public IEnumerable<MessDiary> getTopic()
        {
            var dbContext = new DiaryDb();
            return dbContext.MessDiaries.ToArray();
        }

        public void getComments(int? id)
        {
            var dbContext = new DiaryDb();

        }

        public void clearMess()
        {

        }

    }
}