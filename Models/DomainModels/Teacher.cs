﻿using System.ComponentModel.DataAnnotations;

namespace ClassSchedule.Models.DomainModels
{
	public class Teacher
	{
		public Teacher() => Classes = new HashSet<Class>();
		public int TeacherId { get; set; }
		[Display(Name = "First Name")]
		[StringLength(100, ErrorMessage = "First name may not exceed 100 characters.")]
		[Required(ErrorMessage = "Please enter a first name.")]
		public string FirstName { get; set; }
		[Display(Name = "Last Name")]
		[StringLength(100, ErrorMessage = "Last name may not exceed 100 characters.")]
		[Required(ErrorMessage = "Please enter a last name.")]
		public string LastName { get; set; }
		public string FullName => $"{FirstName} {LastName}";
		public ICollection<Class> Classes { get; set; } 
	}
}
