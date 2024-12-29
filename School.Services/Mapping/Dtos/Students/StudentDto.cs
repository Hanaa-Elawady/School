﻿namespace School.Services.Mapping.Dtos.Students
{
    public class StudentDto
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public ICollection<Guid>? SubjectsId { get; set; }

    }
}
