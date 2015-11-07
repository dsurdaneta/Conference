using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Conference.Models
{
    public class ConferenceContextInitializer : DropCreateDatabaseAlways<ConferenceContext>
    {
        protected override void Seed(ConferenceContext context)
        {
            context.Sessions.Add(
                new Session
                {
                    Title = "I Want Spaghetti",
                    Abstract = "The life of a spaghetti lover",
                    Speaker = context.Speakers.Add(
                              new Speaker() { Name="John Doe",
                                              EmailAddress = "john.doe@test.com"})
                });

            context.SaveChanges();
            //base.Seed(context);
        }
    }
}