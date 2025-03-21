﻿using System.ComponentModel.DataAnnotations;

namespace BeSpokedBikesAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime StartDate { get; set; }
    }
}
