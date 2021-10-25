using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PersonSkill.DataModels
{
   public static class Repository
    {
        public static IEnumerable<Person> GetPersons(Conext conext)
        {
            return conext.Persons.Include(person => person.Skills).ToList();
        }
        
        public static Person GetPersonById(Conext conext, long personId)
        {
            return conext.Persons.Include(person => person.Skills)
                .FirstOrDefault(person => person.PersonId == personId);
        }

        public static void AddPerson(Conext conext, Person newPerson)
        {
            conext.Persons.Add(newPerson);
            conext.SaveChanges();
        }

        public static void DetectChangeSkill(Conext conext,string personName, string skillName, byte newLevel)
        {
            conext.ChangeTracker.AutoDetectChangesEnabled = false;
            Person person = conext.Persons.Include(sk => sk.Skills).First(p => p.Name == personName);
            Skill ownerSkill = person.Skills.First(ns => ns.Name == skillName);
            ownerSkill.Level = newLevel;
            conext.ChangeTracker.AutoDetectChangesEnabled = true;
            Console.WriteLine(conext.ChangeTracker.DebugView.LongView);
            conext.SaveChanges();
        }
        
        public static void DeletePerson(Conext context, long personId)
        {
            Person person = context.Persons.SingleOrDefault(value => value.PersonId.Equals(personId));

            if (person != null) 
            {
                context.Entry(person).Collection(value => value.Skills).Load();
                context.Persons.Remove(person);
            }

            context.SaveChanges();
        }
    }
}
