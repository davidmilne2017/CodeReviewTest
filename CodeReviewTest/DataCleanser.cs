using System;
using System.IO;
using System.Linq;
using CodeReviewTest.Repositories;
using Newtonsoft.Json;

namespace CodeReviewTest
{
    public class DataCleanser
    {
        public void CleanseData(string filePath)
        {

            var httpRepository = new StandardHttpRepo();
            var fileString = File.ReadAllText(filePath);
            var person = JsonConvert.DeserializeObject<Person>(fileString);

            //Capitalise First and Last Names & place of birth
            person.FirstName = Capitalise(person.FirstName);
            person.lastName = Capitalise(person.lastName);
            person.placeOfBirth = Capitalise(person.lastName);

            //Capitalise titles and generate title summary
            var titles = person.PublishedTitles.ToList();
            var titleSummary = "";
            foreach (var title in titles)
            {
                title.Title = Capitalise(title.Title);
                titleSummary += title.Title;
            }

            person.PublishedTitlesSummary = titleSummary;

            var success = httpRepository.SendPerson(person, "https://personrepo.com/api/people");
            Console.WriteLine("Great Success!");

        }

        public string Capitalise(string stringToCapitalise) =>
            char.ToUpper(stringToCapitalise[0]).ToString() + stringToCapitalise.Substring(1);

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string placeOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
        public string Bio { get; set; }
        public PublishedTitle[] PublishedTitles { get; set; }
        public string PublishedTitlesSummary { get; set; }
    }

    public class PublishedTitle
    {
        public string Title { get; set; }
        public DateTime Publishingdate { get; set; }
        public int ISBN { get; set; }
    }
}
