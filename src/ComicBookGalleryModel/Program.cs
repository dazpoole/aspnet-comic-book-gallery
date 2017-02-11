using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookGalleryModel.Models;
using System.Data.Entity;
using System.Diagnostics;
using System.Xml.Serialization.Configuration;

namespace ComicBookGalleryModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {

                //var comicBookId = 1;

                //var comicBook1 = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .Include(cb => cb.Artists.Select(a => a.Artist))
                //    .Include(cb => cb.Artists.Select(a => a.Role))
                //    .SingleOrDefault(cb => cb.Id == comicBookId);

                //Debug.WriteLine("Changing the Description property value.");
                //comicBook1.Description = "New value!";

                //var comicBook2 = context.ComicBooks
                //    .SingleOrDefault(cb => cb.Id == comicBookId);



                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();
                foreach (var comicBook in comicBooks)
                {

                    var artistRoleNames = comicBook.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistsRoleDisplayText = string.Join(", ", artistRoleNames);

                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistsRoleDisplayText);
                }

                Console.ReadLine();
            }
            
        }
    }
}
