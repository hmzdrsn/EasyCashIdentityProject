using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MimeKit;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int code = rnd.Next(100000, 1000000);

                AppUser appUser = new AppUser
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "testcity",
                    District = "testDistrict",
                    ImageUrl = "testImgUrl",
                    ConfirmCode = code
                }; 
                var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);
                if(result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddress = new MailboxAddress("Easy Cash Adming","hmzdrsn64@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddress);//kimden
					mimeMessage.To.Add(mailboxAddressTo);//kime

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code;

                    mimeMessage.Body=bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    SmtpClient client = new();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("hmzdrsn64@gmail.com", "jynqvjvkzyovpiec");//gmailyönet uygulama şifresi
                    client.Send(mimeMessage);
                    client.Disconnect(true);


					return RedirectToAction("Index","ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
