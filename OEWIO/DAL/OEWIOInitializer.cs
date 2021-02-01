using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OEWIO.Models;

namespace OEWIO.DAL
{
    public class OEWIOInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OEWIOContext>
    {
        protected override void Seed(OEWIOContext context)
        {
            var authors = new List<OEWIOAuthor>
            {
            new OEWIOAuthor{FirstName="Chuck",LastName="Bartles"},
            new OEWIOAuthor{FirstName="Dodge",LastName="Billingsley"},
            new OEWIOAuthor{FirstName="Robert",LastName="Bunker"},
            new OEWIOAuthor{FirstName="Ryan",LastName="Cabana"},
            new OEWIOAuthor{FirstName="Geoff",LastName="Demarest"},
            new OEWIOAuthor{FirstName="Robert",LastName="Feldman"},
            new OEWIOAuthor{FirstName="Ray",LastName="Finch"},
            new OEWIOAuthor{FirstName="Les",LastName="Grau"},
            new OEWIOAuthor{FirstName="MIhsan",LastName="Gündüz"},
            new OEWIOAuthor{FirstName="Joseph",LastName="Hartung"},
            new OEWIOAuthor{FirstName="Cindy",LastName="Hurst"},
            new OEWIOAuthor{FirstName="Sura",LastName="Jaradat"},
            new OEWIOAuthor{FirstName="Karen",LastName="Kaya"},
            new OEWIOAuthor{FirstName="Adam",LastName="Rodger"},
            new OEWIOAuthor{FirstName="Michael",LastName="Rubin"},
            new OEWIOAuthor{FirstName="Matthew",LastName="Stein"},
            new OEWIOAuthor{FirstName="Thomas",LastName="Tolare"},
            new OEWIOAuthor{FirstName="Tom",LastName="Wilhelm"},
            new OEWIOAuthor{FirstName="Lucas",LastName="Winter"},
            new OEWIOAuthor{FirstName="Peter",LastName="Wood"},
            new OEWIOAuthor{FirstName="Jacob",LastName="Zenn"}
            };

            authors.ForEach(s => context.OEWIOAuthor.Add(s));
            context.SaveChanges();
            var articles = new List<OEWIOArticle>
            {
            //new OEWIOArticle{Article="Chemistry",},
            //new OEWIOArticle{Article="Microeconomics",},
            //new OEWIOArticle{Article="Macroeconomics",},
            //new OEWIOArticle{Article="Calculus",},
            //new OEWIOArticle{Article="Trigonometry",},
            //new OEWIOArticle{Article="Composition",},
            //new OEWIOArticle{Article="Literature",}
            };
            articles.ForEach(s => context.OEWIOArticle.Add(s));
            context.SaveChanges();
            var products = new List<OEWIOProduct>
            {
            //new OEWIOProduct{StudentID=1,CourseID=1050,Title="Chemistry"},
            //new OEWIOProduct{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new OEWIOProduct{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new OEWIOProduct{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new OEWIOProduct{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new OEWIOProduct{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new OEWIOProduct{StudentID=3,CourseID=1050},
            //new OEWIOProduct{StudentID=4,CourseID=1050,},
            //new OEWIOProduct{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new OEWIOProduct{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new OEWIOProduct{StudentID=6,CourseID=1045},
            //new OEWIOProduct{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            products.ForEach(s => context.OEWIOProduct.Add(s));
            context.SaveChanges();
        }
    }
}
