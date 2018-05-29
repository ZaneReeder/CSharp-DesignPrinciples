using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    // Both High-Level Modules and Low-Level Modules should depend on Abstractions.
    // Abstractions should not depend on details; details should depend on Abstractions.

    // Solution: Form of abstraction by defining interface for how the 
    // relationships class allows access to high level data

    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public class Person
    {
        public string Name;
        // public DateTime DateOfBirth
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // low-level
    public class Relationships : IRelationshipBrowser
    {
        private readonly List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public List<(Person, Relationship, Person)> Relations => relations;

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var r in relations.Where(
                x => x.Item1.Name == name &&
                x.Item2 == Relationship.Parent
                ))
            {
                yield return r.Item3;
            }
        }
    }

    // high-level
    public class Research
    {

        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var r in relations.Where(
        //        x => x.Item1.Name == "John" &&
        //        x.Item2 == Relationship.Parent
        //        ))
        //    {
        //        Console.WriteLine($"John has a child called {r.Item3.Name}");
        //    }
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
                Console.WriteLine($"John has a child called {p.Name}");
        }

        static void Main(string[] args)
        {
            var parent1 = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent1, child1);
            relationships.AddParentAndChild(parent1, child2);

            new Research(relationships);
            
        }
    }
}
