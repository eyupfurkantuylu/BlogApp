using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Author
	{
		[Key]
		public int AuthorID { get; set; }
		public string? AuthorName { get; set; }
		public string? AuthorAbout { get; set; }
		public string? AuthorImage { get; set; }
		public string? AuthorMail { get; set; }
		public bool AuthorEmailConfirmed { get; set; }
		public DateTime? AuthorLastLogin { get; set; }
		public string? AuthorLastLoginIP { get; set; }
		public DateTime? AuthorBirthDate { get; set; }
		public string? AuthorLanguages { get; set; }
		public string? AuthorContactEmail { get; set; }
		public string? AuthorContactPhoneNumber { get; set; }

		public string? AuthorPassword { get; set; }
		public bool AuthorStatus { get; set; }
		public string? AuthorFacebookProfile { get; set; }
		public string? AuthorTwitterProfile { get; set; }
		public string? AuthorLinkedInProfile { get; set; }
		public string? AuthorCountry { get; set; }  // Ülke
		public string? AuthorCity { get; set; }     // Şehir
		public string? AuthorNeighborhood { get; set; }  // Mahalle
		public string? AuthorStreet { get; set; }   // Sokak
		public string? AuthorZipCode { get; set; }  // Posta Kodu
		public string? AuthorPhoneNumber { get; set; }
		public string? PersonalWebsite { get; set; }
		public string? AuthorResume { get; set; }
		public DateTime AuthorRegistrationDate { get; set; }
		public List<Blog>? Blogs { get; set; }


	}
}

