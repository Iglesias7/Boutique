using System;
using System.Collections.Generic;

namespace shop.Models {
    
    public class UserDTO {
        public int Id {get; set;}
        public string Pseudo {get; set;}
        public string Password {get; set;}
        public string Email {get; set;}
        public string LastName {get; set;}
        public string FirstName {get; set;}
        public DateTime? BirthDate {get; set;}
        public int Reputation {get; set;}
        public string PicturePath { get; set; }
        public Role Role { get; set; }
        public string Token {get;set;}
        public string RefreshToken { get; set; }
    }
}