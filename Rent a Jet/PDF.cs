using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Models;

namespace Rent_a_Jet
{
    public class PDF
    {
        public static void generatePDF(CharterTransaction transaction) {
            Document pdfDocument = new Document();
            PdfWriter.GetInstance(pdfDocument, new FileStream("..\\..\\..\\reciept.pdf", FileMode.Create));
            pdfDocument.Open();
            string heading = "Charter contract (fixed price)\n";
            heading+= "between\n";
            heading += "RENTAJET AG (customer)\n";
            heading += "and\n";
            heading += "Company or Person (Client)\n";
            Phrase p1Header = new Phrase(heading, FontFactory.GetFont("verdana", 11, Font.BOLD));
            Paragraph header = new Paragraph(p1Header);
            header.Alignment = Element.ALIGN_CENTER;
            pdfDocument.Add(header);
            pdfDocument.Close();
        }
    }
}
