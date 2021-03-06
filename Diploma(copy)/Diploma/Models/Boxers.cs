using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diploma
{
    public partial class Boxers
    {
        public int BoxerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? TrainingExperience { get; set; }
        public int? NumberOfFightsHeld { get; set; }
        public int? NumberOfWins { get; set; }
        public string Discharge { get; set; }
        public int? CoachId { get; set; }
        public int? BoxingClubId { get; set; }

        public virtual BoxingClubs BoxingClub { get; set; }
        public virtual Coaches Coach { get; set; }
    }
}
