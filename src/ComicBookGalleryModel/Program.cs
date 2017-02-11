using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookGalleryModel.Models;
using System.Data.Entity;
using System.Xml.Serialization.Configuration;

namespace ComicBookGalleryModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {

                var series = new Series()
                {
                    Title = "The Amazing Spider-Man"
                };

                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });

                context.ComicBooks.Add(new ComicBook()
                {
                    Series = series,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                });

                context.SaveChanges();

                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .ToList();
                foreach (var comicBook in comicBooks)
                { 
                    Console.WriteLine(comicBook.DisplayText);
                }

                Console.ReadLine();
            }
            
        }
    }
}
