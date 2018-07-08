using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Person
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{ nameof(Name) }: { Name }, { nameof(Position) }: { Position }";
        }
    }

    public abstract class PersonBuilder
    {
        //protected not private because using inheritance
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    // class Foo : Bar<Foo> 
    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {

        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<SELF>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAs(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }


    //FACETED BUILDER
    public class Person2
    {
        //address
        public string StreetAddress, PostCode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}:{StreetAddress}, {nameof(PostCode)}:{PostCode}, {nameof(City)}:{City}, {nameof(CompanyName)}:{CompanyName}, {nameof(Position)}:{Position}, {nameof(AnnualIncome)}:{AnnualIncome}";
        }
    }

    public class PersonBuilder2 // facade
    {
        // reference!
        protected Person2 person = new Person2();

        public PersonJobBuilder2 Works => new PersonJobBuilder2(person);

        public PersonAddressBuilder2 Lives => new PersonAddressBuilder2(person);

        public static implicit operator Person2(PersonBuilder2 pb)
        {
            return pb.person;
        }
    }


    public class PersonJobBuilder2 : PersonBuilder2
    {
        public PersonJobBuilder2(Person2 person)
        {
            this.person = person;
        }

        public PersonJobBuilder2 At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder2 As(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder2 Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }


    public class PersonAddressBuilder2 : PersonBuilder2
    {
        // must use reference type
        public PersonAddressBuilder2(Person2 person)
        {
            this.person = person;
        }

        public PersonAddressBuilder2 InCity(string city)
        {
            person.City = city;
            return this;
        }

        public PersonAddressBuilder2 OnStreet(string street)
        {
            person.StreetAddress = street;
            return this;
        }

        public PersonAddressBuilder2 WithCode(string code)
        {
            person.PostCode = code;
            return this;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //var hello = "hello";
            //var sb = new StringBuilder();
            //sb.Append("<p>");
            //sb.Append(hello);
            //sb.Append("</p>");
            //Console.WriteLine(sb);

            //var words = new[] { "hello", "world" };
            //var sb = new StringBuilder();
            //sb.Append("<ul>");
            //foreach (var word in words)
            //{
            //    sb.AppendFormat("<li>{0}</li>", word);
            //}
            //sb.Append("</ul>");
            //Console.WriteLine(sb);

            //var builder = new HtmlBuilder("ul");

            ////create fluency by returning itself in the AddChild method.
            //builder
            //    .AddChild("li", "hello")
            //    .AddChild("li", "hello")
            //    .AddChild("li", "hello");
            //Console.WriteLine(builder.ToString());


            //builders inheriting other builders
            //if builders use fluent approach then trouble arises.
            //Implementing recursive generics

            //var builder = new PersonJobBuilder();
            //builder.Called("Zane")
            //    .WorksAsA("dev");

            //var myself = Person.New
            //    .Called("Zane")
            //    .WorksAs("Dev");

            //FACETED BUILDER
            //var pb = new PersonBuilder2();
            //Person2 person = pb
            //      .Lives.InCity("Lubbock")
            //            .WithCode("75555")
            //            .OnStreet("Frankford")
            //      .Works.At("Apple")
            //            .As("Engineer")
            //            .Earning(100000);
            //Console.WriteLine(person);


            //CODING EXERICSE
            //Chunks of C# Code Renderer using Builder design
            var cb = new CodeBuilder("Person");
            cb.AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb.ToString());



        }
    }
}
