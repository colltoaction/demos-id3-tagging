using System;
using System.IO;
using TagLib;

namespace ID3Tagging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string path = @"clip.mp3";
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var fileStreamAbstraction = new StreamFileAbstraction(path,
                     fileStream, fileStream);
                var tagFile = TagLib.File.Create(fileStreamAbstraction);
                var tags = tagFile.GetTag(TagTypes.Id3v2);
                Console.WriteLine($"Title\t\t{tags.Title}");
                Console.WriteLine($"Artist\t\t{tags.JoinedAlbumArtists}");
                Console.WriteLine($"Comment\t\t{tags.Comment}");
                Console.ReadLine();
            }
        }
    }
}
