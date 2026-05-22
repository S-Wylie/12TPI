namespace MakeLabels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String name;
            String subject;
            Console.WriteLine("Please enter your name");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your subject");
            subject = Console.ReadLine();
            Console.WriteLine("**********");
            Console.WriteLine("Name: "+name);
            Console.WriteLine("Subject: "+subject);
            Console.WriteLine("**********");
            Console.WriteLine(subject + name);
        }
    }
}
