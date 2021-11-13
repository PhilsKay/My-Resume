using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myresume.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Myresume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //Get Resume PDF
        public IActionResult Resume()
        {
            byte[] asByte;
            using (MemoryStream os = new MemoryStream())
            using(PdfWriter writer = new PdfWriter(os))
            using (PdfDocument pdf = new PdfDocument(writer))
            using (Document doc = new Document(pdf)) 
            { 
                Paragraph empty = new Paragraph();
                PdfFont headingFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                PdfFont normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                // Icons directory
             /*   string location = "C:/Users/danikay tech/Downloads/Sign Location.G03.watermarked.2k.png";
                string contact = "C:/Users/danikay tech/Downloads/Handset Blue.G03.watermarked.2k.png";
                string email = "C:/Users/danikay tech/Downloads/Email Blue Icon.G03.watermarked.2k.png";
                string[] icons = { location, contact, email };
                  ImageData locationImage =  ImageDataFactory.Create(location);
              
                ImageData emailImage = ImageDataFactory.Create(email);
                
                ImageData contactIimage = ImageDataFactory.Create(contact);
                contactIimage.SetHeight(15f);
                contactIimage.SetWidth(15f);
             */
                //My name
                Paragraph myName = new Paragraph("Kayode Philip").SetFontSize(45)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFont(headingFont);
                myName.SetFontColor(ColorConstants.BLUE);
                doc.Add(myName);
                //specialization
                Paragraph job = new Paragraph("BACKEND WEB DEVELOPER").SetFontSize(10)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFont(normalFont);
                job.SetFixedPosition(35, 730, 400);
                doc.Add(job);
                //address and contact
                List list = new List();
                string addressText = "49, Ayobo Road, Lagos State, Nigeria.";
                string contacttext = "+2348053916863";
                string emailText = "philipinhokayode@gmail.com";
                string[] info = { addressText, contacttext, emailText };
                foreach(string infos in info)
                {
                    list.Add(infos).SetFont(headingFont);
                }
                doc.Add(empty);
                doc.Add(list);

                //linkedin and github
                string linkedin = "linkedin.com/in/kayode-philip-324503216";
                string github = "github.com/PhilsKay";
                string[] social = { linkedin, github };
                List forSocial = new List();
                foreach (string socials in social)
                {
                    forSocial.Add(socials).SetFont(headingFont).SetFixedPosition(275,690,400)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
                }
                doc.Add(empty);
                doc.Add(forSocial);
                doc.Add(empty);
                //about me section
                string me = "Self-motivated backend web developer with 1 year of experience coding websites that solve business problems. Addition of improved logical functionalities and databases. I look forward and happy to work with you for better development.";
                Paragraph aboutMe = new Paragraph(me).SetFont(headingFont);
                doc.Add(aboutMe);
                //Education section
                string education = "EDUCATION";
                string course = "Systems Engineering";
                string school = "UNIVERSITY OF LAGOS, NIGERIA";
                List edu = new List();
                edu.Add(education).SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFont(normalFont);
                SolidLine line = new SolidLine();
                LineSeparator separator = new LineSeparator(line);
                doc.Add(edu);
                doc.Add(separator);
                
                doc.Add(empty);
                Paragraph courseName = new Paragraph(course).SetFontSize(20).SetFontColor(ColorConstants.BLUE)
                    .SetFont(headingFont);
                doc.Add(courseName);
                Paragraph schoolName = new Paragraph(school).SetFontSize(10)
                   .SetFont(normalFont).SetMarginTop(0f);
                doc.Add(schoolName);
                //set school year...
                Paragraph schoolYear = new Paragraph("2021 - 2026").SetFont(normalFont).SetFixedPosition(450, 505, 400)
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(10);
                doc.Add(schoolYear);

                //My work experience Heading
                List work = new List();
                work.Add("WORK EXPERIENCE").SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFont(normalFont);
                LineSeparator separatore = new LineSeparator(line);
                doc.Add(work);
                doc.Add(separator);
                doc.Add(empty);
                //Accomplishment oNE
                string workOne = "Automatic Certificate Generator Website";
                string employerOne = "FOR A COMMUNITY";
                string descriptionOne = "A website that issues certificates to members of the community after the completion of any program with their names written on the certificate. Its has security system that prevents unauthorized access to the certificate generator. I used ASP.NET Core, HTML, CSS and itext 7 library in development of the website.";
                    Paragraph myworkOne = new Paragraph(workOne).SetFontSize(20).SetFontColor(ColorConstants.BLUE)
               .SetFont(headingFont);
                    doc.Add(myworkOne);
                Paragraph myEmployerone = new Paragraph(employerOne).SetFontSize(10)
                   .SetFont(normalFont).SetMarginTop(0f);
                doc.Add(myEmployerone);
                //set  year...
                Paragraph myEmployerOneYear = new Paragraph("2021").SetFont(normalFont).SetFixedPosition(450, 413, 400)
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(10);
                doc.Add(myEmployerOneYear);
                Paragraph myDescriptionOne = new Paragraph(descriptionOne).SetFont(headingFont);
                doc.Add(myDescriptionOne);

                // accomplishment Two
                string workTwo = "Quiz Website";
                string employerTwo = "PERSONAL PROJECT";
                string descriptionTwo = " Users have access to take the available quiz in the website, users must register and login their accounts. Website has so much functionalities as related to the backend and good User Interface. Used aASP.NET Core, MySQL, HTML, CSS and  Identity API.";

                Paragraph myworkTwo = new Paragraph(workTwo).SetFontSize(20).SetFontColor(ColorConstants.BLUE)
                .SetFont(headingFont);
                doc.Add(myworkTwo);
                Paragraph myEmployerTwo = new Paragraph(employerTwo).SetFontSize(10)
                   .SetFont(normalFont).SetMarginTop(0f);
                doc.Add(myEmployerTwo);
                //set year...
                Paragraph myEmployerTwoYear = new Paragraph("2021").SetFont(normalFont).SetFixedPosition(450, 292, 400)
                       .SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(10);
                doc.Add(myEmployerTwoYear);
                Paragraph myDescriptionTwo = new Paragraph(descriptionTwo).SetFont(headingFont);
                doc.Add(myDescriptionOne);

                // My skills section
                List personal = new List();
                personal.Add("PROFESIONAL SKILLS").SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFont(normalFont);
                doc.Add(personal);
                doc.Add(separator);
                doc.Add(empty);

                List skills = new List();
                skills.SetListSymbol("\u2022");
                skills.Add("C#").SetFont(headingFont);
                skills.Add("ASP.NET Core").SetFont(headingFont);
                skills.Add("MySQL/MsSQL").SetFont(headingFont);
              
                doc.Add(skills);
                //for the remaining skills
                List subSkills = new List();
                subSkills.SetListSymbol("\u2022");
                subSkills.Add("RESTFUL API").SetFont(headingFont).SetFixedPosition(200, 135, 400);
                subSkills.Add("HTML/CSS").SetFont(headingFont);
                subSkills.Add("Azure").SetFont(headingFont);
                doc.Add(subSkills);

                // My pERSONAL skills section
                List personal2 = new List();
                personal2.Add("PERSONAL SKILLS").SetFontSize(15).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFont(normalFont);
                doc.Add(personal2);
                doc.Add(separator);

                List skills2 = new List();
                skills2.SetListSymbol("\u2022");
                skills2.Add("communication").SetFont(headingFont);
                skills2.Add("Team work").SetFont(headingFont);
               
                doc.Add(skills2);
                //for the remaining personal skills
                List subSkills2 = new List();
                subSkills2.SetListSymbol("\u2022");
                subSkills2.Add("Logic").SetFont(headingFont).SetFixedPosition(200, 77, 400);
                subSkills2.Add("Creativity").SetFont(headingFont);
                doc.Add(subSkills2);

                // My Language
                List Language = new List();
                Language.Add("LANGUAGE").SetFontSize(15).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT)
                    .SetFont(normalFont);
                doc.Add(separator);
                doc.Add(Language);
                List lan = new List();
                lan.SetListSymbol("\u2022");
                lan.Add("English").SetFont(headingFont);
                doc.Add(lan);

                doc.Close();
                doc.Flush();
                asByte = os.ToArray();
            }
            return new FileContentResult(asByte, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
