using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeWork.Models;

namespace PracticeWork.Service
{
    public class MovieDBService
    {
        //實作資料庫模型
        public PracticeWork.Models.MovieDatabase1Entities db = new
            Models.MovieDatabase1Entities();
        
        //此方法取得資料庫中,Article資料表的資料並回傳
        public List<Article> GetData()
        {
            return (db.Article.ToList());
        }
        //此方法將接收的資料存入資料庫
        public void DBCreate(string Article_title,string Content)
        {
            Article NewData = new Article();//實作資料表Article
            NewData.Title = Article_title;//此變數用於儲存文章標題
            NewData.Content = Content;//此變數用於儲存內容標題
            NewData.time = DateTime.Now;//此變數用於儲存文章發表的時間
            db.Article.Add(NewData);//新增一筆資料
            db.SaveChanges();//儲存資料庫變更
        }
    }
}