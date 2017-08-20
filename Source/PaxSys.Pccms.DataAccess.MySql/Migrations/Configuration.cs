//using System.Collections.Generic;
//using DataAccess.Context;
//using Domain.Models;
//using Domain.Utility;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//
//namespace DataAccess.Migrations
//{
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;
//
//    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Context.ParafiadaContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//            ContextKey = "DataAccess.Context.ParafiadaContext";
//        }
//        
//            protected override void Seed(ParafiadaContext context)
//        {
//            if (!context.Users.Any())
//                RunSeed(context);
//
//            base.Seed(context);
//        }
//
//        private void RunSeed(ParafiadaContext context)
//        {
//
//            var newUser = new User { UserName = "admin@admin.com" };
//
//            if (!(context.Users.Any(u => u.UserName == "admin@admin.com")))
//            {
//                var userStore = new UserStore<User>(context);
//                var userManager = new UserManager<User>(userStore);
//                userManager.Create(newUser, "asdasd");
//            }
//
//            var newGroup = new Group()
//            {
//                Name = "Kowalczuki",
//                Description = "Test grupa Kowalczuki",
//                GroupScore = 0,
//
//            };
//
//            context.Groups.Add(newGroup);
//
//            var newMember1 = new Member()
//            {
//                Name = "Vardenis",
//                Surname = "Pavardenis",
//                DateOfBirth = new DateTime(1997, 11, 24),
//                PersonalScore = 0,
//                AttendedGroup = newGroup
//            };
//
//            var newMember2 = new Member()
//            {
//                Name = "Pan",
//                Surname = "Tadeusz",
//                DateOfBirth = new DateTime(1950, 2, 11),
//                PersonalScore = 0,
//                AttendedGroup = newGroup
//            };
//
//            context.Members.Add(newMember1);
//            context.Members.Add(newMember2);
//
//
//            var newActivity = new Activity()
//            {
//                Name = "Bieg 100m",
//                AttendingMembers = new List<MemberActivityAttendance>(),
//                AttendingTeams = new List<TeamActivityAttendance>(),
//                ScoreType = Enums.ScoreType.Meters,
//                Type = Enums.ActivityType.Personal,
//                FirstPlaceValue = 5,
//                SecondPlaceValue = 3,
//                ThirdPlaceValue = 1,
//            };
//            context.Activities.Add(newActivity);
//
//            var newAttendance1 = new MemberActivityAttendance()
//            {
//                AttendedMember = newMember1,
//                Activity = newActivity,
//            };
//
//            var newAttendance2 = new MemberActivityAttendance()
//            {
//                AttendedMember = newMember2,
//                Activity = newActivity,
//            };
//            context.MemberActivityAttendances.Add(newAttendance1);
//            context.MemberActivityAttendances.Add(newAttendance2);
//
//            var newContest = new Contest()
//            {
//                Description = "TestContest",
//                ContestDate = new DateTime(2017, 10, 10),
//                IsOver = false,
//                OwnerUser = newUser,
//                AttendingGroups = new List<Group>(),
//                Activities = new List<Activity>()
//            };
//
//            newContest.AttendingGroups.Add(newGroup);
//            newContest.Activities.Add(newActivity);
//
//            context.Contests.Add(newContest);
//
//        }
//    }
//}
