using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasyCashIdentityProject.PresentationLayer.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{

			return new IdentityError {
				Code="PasswordTooShort",
				Description=$"Şifreniz en az {length} karakter olmalıdır."
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "En Az 1 büyük harf kullanınız."
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresLower",
				Description = "En Az 1 küçük harf kullanınız."
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError 
			{
				Code= "PasswordRequiresDigit",
				Description= "En Az 1 rakam kullanınız."
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "En Az 1 sembol kullanınız."
			};
		}
	}
}
