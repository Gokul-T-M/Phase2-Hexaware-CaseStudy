﻿using System.ComponentModel.DataAnnotations;

namespace AmazeCare.API.DTOs.AuthDTOs
{
    public class RegisterAdminDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        //[MinLength(6)]
        public string Password { get; set; }
    }
}
