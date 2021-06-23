namespace CodeReviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataCleanser = new DataCleanser();
            dataCleanser.CleanseData("c:\temp\person.json");
        }
    }
}
