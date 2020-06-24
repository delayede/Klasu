using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication7
{
    public class Person
    {

        private string name;

        private string secondName;

        private DateTime date;

        public Person(string name, string secondName, DateTime date)

        {

            this.name = name;

            this.secondName = secondName;

            this.date = date;

        }

        public Person()

        {

            name = "Jason";

            secondName = "Schreier";

            date = new DateTime(1976, 5, 4);

        }

        public string Name

        {

            get { return name; }

            set { name = value; }

        }

        public string SecondName

        {

            get { return secondName; }

            set { secondName = value; }

        }

        public DateTime Date

        {

            get { return date; }

            set { date = value; }

        }

        public int Year

        {

            get { return date.Year; }

            set { date = new DateTime(value, date.Month, date.Day); }

        }

        public override string ToString()

        {

            return " Name: " + name + "\n" + " SecondName: " + secondName + "\n" + " Birth Date: " + date.ToShortDateString();

        }

        public virtual string ToShortString()

        {

            return "Name: " + name + "\n" + "SecondName: " + secondName;

        }
    }

    class Paper

    {

        string name;
        Person author;
        DateTime datePaper;
    
        public Paper(string name, Person author, DateTime datePaper)

        {

            this.name = name;

            this.author = author;

            this.datePaper = datePaper;

        }


        public Paper()

        {

            name = " Try Harder";

            author = new Person();

            datePaper = new DateTime(2000, 1, 1);

        }
        public string Name

        {

            get { return name; }

            set { name = value; }

        }
        public Person Author

        {

            get { return author; }

            set { author = value; }

        }

        public DateTime Date

        {

            get { return datePaper; }

            set { datePaper = value; }

        }
        public override string ToString()

        {

            return "\n Title of publication: " + name + "\n Post author: \n" + author.ToString() + "\n Publication Date: " + datePaper.ToShortDateString();

        }

        public object DeepCopy()

        {

            Paper paper = new Paper(this.name, this.author, this.datePaper);

            return paper;

        }



        public Paper(string publication, DateTime time)
        {
            Publication = publication;
            Time = time;
        }
        public string Publication;

        public DateTime Time;

    }

    
    enum TimeFrame { Year, TwoYears, Long }
   

    class ResearchTeam
    {

        private string theme;        
        private string nameOfOrg;    
        private int numberOfRed;    
        private TimeFrame time;     
        private Paper[] papers;


        public ResearchTeam(string theme, string nameOfOrg, int numberOfRed, TimeFrame time)
        {
            this.theme = theme;
            this.nameOfOrg = nameOfOrg;
            this.numberOfRed = numberOfRed;
            this.time = time;
            papers = new Paper[0];

        }


       
        public ResearchTeam() {

            theme = " CyberPunk";
            nameOfOrg = " CDProdject";
            numberOfRed = 1;
            time = TimeFrame.Year;
            papers = new Paper[0];


        }


        
        public string Theme
        {
            get { return theme; }
            set { theme = value; }
        }

        
        public string Nameoforg
        {
            get { return nameOfOrg; }
            set { nameOfOrg = value; }
        }

       
        public int Numberofred
        {
            get { return numberOfRed; }
            set { numberOfRed = value; }
        }

               public TimeFrame Time
        {
            get { return time; }
            set { time = value; }
        }
        public Paper[] Papers

        {

            get { return papers; }

            set { papers = value; }

        }
        public void AddPaper(params Paper[] paperAdd)

        {

            int Length = papers.Length;

            Array.Resize<Paper>(ref papers, Length + paperAdd.Length);

            paperAdd.CopyTo(papers, Length);

        }
        

        public override string ToString()

        {

            string result = base.ToString() + "\n Research topic: " + theme.ToString() + "\n Name of the organization:" + nameOfOrg.ToString() + "\n Register number: " + numberOfRed.ToString() + "\n Research duration:" + time.ToString();

            //if(exams.Length != 0)

            foreach (Paper e in papers)

            {

                result += e.ToString() + "\n";

            }
            return result;
        }

        new public string ToShortString()

        {

            string result = base.ToString() + "\n Research topic: " + theme.ToString() + "\n Name of the organization:" + nameOfOrg.ToString() + "\n Register number: " + numberOfRed.ToString() + "\n Research duration:" + time.ToString();

            return result;

        }
        public bool this[TimeFrame index]
        {
            get
            {
                if (time == index)
                {
                    return true;
                }
                else
                    return false;
            }

        }
    }
        class Program
        {
            static void Main(string[] args)
            {
            Console.WriteLine("1");
            Console.WriteLine();
                ResearchTeam researchTeam = new ResearchTeam();

                Console.WriteLine(researchTeam.ToShortString());
            Console.WriteLine();
            Console.WriteLine("2");

            Console.WriteLine(TimeFrame.Year + " " + researchTeam[TimeFrame.Year]);
            Console.WriteLine(TimeFrame.TwoYears + " " + researchTeam[TimeFrame.TwoYears]);
            Console.WriteLine(TimeFrame.Long + " " + researchTeam[TimeFrame.Long]);

            Console.WriteLine();
            Console.WriteLine("3, 4 ");

              researchTeam.AddPaper(new Paper());
            researchTeam.Theme = " Redemption";
            researchTeam.Nameoforg = " RockStar";
            researchTeam.Numberofred = 15;
           
            Console.WriteLine(researchTeam.ToString());

            Console.WriteLine();

            Console.ReadKey();
            }
        }
    }

