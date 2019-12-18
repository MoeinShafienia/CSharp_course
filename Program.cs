using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace charp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //  *** extantion method
            // string input;
            // input = Console.ReadLine();            
            // int inputInt = Convert.ToInt32(input);        
            // Console.WriteLine(inputInt.seprate());

            // DateTime date = DateTime.Now;
            // Console.WriteLine(date.ToPersianDateString());

            // string input = "moein";
            // Console.WriteLine(input.toFarsi());

            // *** interface

            // ICar lamborghini = new  Lamborghini(300,700,2);
            // Console.WriteLine(lamborghini.speed);
            // Console.WriteLine(lamborghini.engine);
            // Console.WriteLine(lamborghini.doors);

            // IEnumerable<int> list = new List<int>();

            // *** LINQ

            int[] array = new int[10];
            Random rand = new Random();
            for (int i =0 ; i < 10 ; i++) {
                array[i] = rand.Next(0,1000);
            }

            // var scoreQuery =
            // from score in array
            // where score > 10
            // select score;

            // int[] sortedCopy = 
            // (from element in array
            // orderby element ascending
            // select element)
            // .ToArray();

            // // foreach(var element in sortedCopy) {
            // //     Console.WriteLine(element);
            // // }

            // var numberOfTwos = 
            // (from element in array
            // where element == 2
            // select element)
            // .Count();

            //Console.WriteLine(numberOfTwos);

            Person person1 = new Person(20,1,"ali","elahi");
            Person person2 = new Person(20,2,"moein","shafienia");
            Person person3 = new Person(20,3,"mohammad","borna");

            List<Person> persons = new List<Person>();
            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);

            Scores score1 = new Scores(1,18,19,20);
            Scores score2 = new Scores(2,14,16,17);
            Scores score3 = new Scores(3,12,18,15);

            List<Scores> scores = new List<Scores>();
            scores.Add(score1);
            scores.Add(score2);
            scores.Add(score3);

            var innerGroupJoinQuery =
            (from person in persons
            join score in scores on person.id equals score.id
            select new { name = person.name,
                         lastName = person.lastName,
                         id = person.id,
                         cPlusPlus = score.cPlusPlus,
                         cSharp = score.cSharp,
                         java = score.java
                          }).ToArray();

            // foreach(var i in innerGroupJoinQuery) {
            //     Console.WriteLine(i.name);
            //     Console.WriteLine(i.lastName);
            //     Console.WriteLine(i.id);
            //     Console.WriteLine(i.cPlusPlus);
            //     Console.WriteLine(i.cSharp);    
            //     Console.WriteLine(i.java);
            // }

    

            var averagePerson = 
            (from p in innerGroupJoinQuery
            select (p.cSharp + p.cPlusPlus + p.java)/3 where p.id == 1)
            .ToList();
            

            

            

            
            


            
        }

    }

    // extention methods

    static class NumberSeprator{

        public static string seprate(this int number) {
            
            return number.ToString("N0", new NumberFormatInfo()
                                            {
                                                NumberGroupSizes = new[] { 3 },
                                                NumberGroupSeparator = ","
                                            });

            
        }


    }

    static class ToPersianCalender{
        public static string ToPersianDateString(this DateTime georgianDate)
        {
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

            string year = persianCalendar.GetYear(georgianDate).ToString();
            string month = persianCalendar.GetMonth(georgianDate).ToString().PadLeft(2,'0');
            string day = persianCalendar.GetDayOfMonth(georgianDate).ToString().PadLeft(2, '0');
            string persianDateString = string.Format("{0}/{1}/{2}", year, month, day);
            return persianDateString;
        }
    }

    static class ToFarsi{

        public static string toFarsi(this string input) {
            return "معین" ;
        }
    }

    /// interfaces

    class Lamborghini : ICar{

        public int speed { get; set; }
        public int engine { get; set; }
        public int doors { get; set; }

        public Lamborghini(int speed,int engine,int doors){
            this.speed = speed;
            this.doors = doors;
            this.engine = engine;
        }

        
    }

    class BMW : ICar{

        public int speed { get; set; }
        public int engine { get; set; }
        public int doors { get; set; }

        public BMW(int speed,int engine,int doors){
            this.speed = speed;
            this.doors = doors;
            this.engine = engine;
        }
        
    }

    class Hyindai : ICar{

        public int speed { get; set; }
        public int engine { get; set; }
        public int doors { get; set; }

        public Hyindai(int speed,int engine,int doors){
            this.speed = speed;
            this.doors = doors;
            this.engine = engine;
        }
        
    }

    interface ICar {
        int speed { get; set; }
        int engine { get; set; }
        int doors { get; set; }


    }
}

//*** LINQ
class Person{
    public string name;
    public string lastName;
    public int age;
    public int id;

    public Person(int age,int id,string name,string lastName) {
        this.age = age;
        this.id = id;
        this.name = name;
        this.lastName = lastName;
    }
}

class Scores{
    public int id;
    public int cSharp;
    public int java;
    public int cPlusPlus;

    public Scores(int id,int cSharp,int java,int cPlusPlus){
        this.id = id;
        this.cPlusPlus = cPlusPlus;
        this.java = java;
        this.cSharp = cSharp;
    }
}

