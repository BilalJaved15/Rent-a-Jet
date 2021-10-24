using System;
using System.Collections.Generic;
using System.Globalization;
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
        public static void generatePDF(CharterTransactionSingle transaction)
        {
            Document pdfDocument = new Document();
            PdfWriter.GetInstance(pdfDocument, new FileStream("..\\..\\..\\reciept.pdf", FileMode.Create));
            pdfDocument.Open();
            string heading = "Charter contract\n";
            heading += "between\n";
            heading += "RENTAJET AG\n";
            heading += "and\n";
            heading += transaction.customer.name + "\n\n";
            Phrase p1Header = new Phrase(heading, FontFactory.GetFont("verdana", 20, Font.BOLD));
            Paragraph header = new Paragraph(p1Header);
            header.Alignment = Element.ALIGN_CENTER;
            pdfDocument.Add(header);
            Paragraph body1 = new Paragraph(transaction.customer.name +
                " charters the aircraft " + transaction.aircraft.type + " with the" +
                " registration number " + transaction.aircraft.id + " for the time" +
                " from " + transaction.departureDate + " to " + transaction.departureDate.AddDays(1) +
                " for a journey from " + transaction.departurePlace + " to " + transaction.destinationPlace + ".");
            body1.Alignment = Element.ALIGN_JUSTIFIED;
            String body2Str = "\n\nTotal charter duration (hours): " +
                24 + "\n" +
                "Of which flight time (h): " + Convert.ToInt32(2000 / 365)
                + "\n\n" + "Total price net: " + transaction.totalCost.ToString("C", CultureInfo.CurrentCulture) +
                "\n19% VAT: " + (transaction.totalCost * (0.19)).ToString("C", CultureInfo.CurrentCulture) +
                "\nTotal price gross: " + (transaction.totalCost + (transaction.totalCost * (0.19))).ToString("C", CultureInfo.CurrentCulture) + "\n\n\n";
            Paragraph body2 = new Paragraph(body2Str);
            body1.Alignment = Element.ALIGN_JUSTIFIED;
            body2.Alignment = Element.ALIGN_LEFT;
            pdfDocument.Add(body1);
            pdfDocument.Add(body2);
            pdfDocument.Add(new Paragraph("Date, Place                                                                                                                    Date, Place"));
            pdfDocument.Add(new Paragraph("RENTAJET                                                                                                                    " + transaction.customer.name));
            pdfDocument.Close();
        }
        public static void generatePDF(CharterTransactionStops transaction)
        {
            Document pdfDocument = new Document();
            PdfWriter.GetInstance(pdfDocument, new FileStream("..\\..\\..\\reciept.pdf", FileMode.Create));
            pdfDocument.Open();
            string heading = "Charter contract\n";
            heading += "between\n";
            heading += "RENTAJET AG\n";
            heading += "and\n";
            heading += transaction.customer.name + "\n\n";
            Phrase p1Header = new Phrase(heading, FontFactory.GetFont("verdana", 20, Font.BOLD));
            Paragraph header = new Paragraph(p1Header);
            header.Alignment = Element.ALIGN_CENTER;
            pdfDocument.Add(header);
            String body1Str = transaction.customer.name +
                " charters the aircraft " + transaction.aircraft.type + " with the" +
                " registration number " + transaction.aircraft.id + " for the time" +
                " from " + transaction.departureDate + " to " + transaction.departureDate.AddDays(transaction.lengthOfStay) +
                " for a journey from " + transaction.departurePlace + " to " + transaction.destinationPlace +
                " via ";
            foreach (String stopover in transaction.stopovers)
            {
                body1Str += stopover + ", ";
            }
            String body2Str = "\n\nTotal charter duration (hours): " +
                transaction.lengthOfStay * 24 + "\n" +
                "Of which flight time (h): " + (2000 / 365 * transaction.lengthOfStay)
                + "\n\n" + "Total price net: " + transaction.totalCost.ToString("C", CultureInfo.CurrentCulture) +
                "\n19% VAT: " + (transaction.totalCost * (0.19)).ToString("C", CultureInfo.CurrentCulture) +
                "\nTotal price gross: " + (transaction.totalCost + (transaction.totalCost * (0.19))).ToString("C", CultureInfo.CurrentCulture) + "\n\n\n";
            Paragraph body1 = new Paragraph(body1Str);
            Paragraph body2 = new Paragraph(body2Str);
            body1.Alignment = Element.ALIGN_JUSTIFIED;
            body2.Alignment = Element.ALIGN_LEFT;
            pdfDocument.Add(body1);
            pdfDocument.Add(body2);
            pdfDocument.Add(new Paragraph("Date, Place                                                                                                                    Date, Place"));
            pdfDocument.Add(new Paragraph("RENTAJET                                                                                                                    " + transaction.customer.name));
            pdfDocument.Close();
        }
        public static void generatePDF(CharterTransactionDuration transaction)
        {
            Document pdfDocument = new Document();
            PdfWriter.GetInstance(pdfDocument, new FileStream("..\\..\\..\\reciept.pdf", FileMode.Create));
            pdfDocument.Open();
            string heading = "Charter contract\n";
            heading += "between\n";
            heading += "RENTAJET AG\n";
            heading += "and\n";
            heading += transaction.customer.name + "\n\n";
            Phrase p1Header = new Phrase(heading, FontFactory.GetFont("verdana", 20, Font.BOLD));
            Paragraph header = new Paragraph(p1Header);
            Paragraph body1 = new Paragraph(transaction.customer.name +
                " charters the aircraft " + transaction.aircraft.type + " with the" +
                " registration number " + transaction.aircraft.id + " for the time" +
                " from " + transaction.departureDate + " to " + transaction.departureDate.AddDays(transaction.charterDuration));
            Paragraph body2 = new Paragraph("\n\nTotal charter period (hours): " + transaction.charterDuration * 24 + "\n\n");
            Paragraph body3 = new Paragraph("The charter price shall be composed of a " +
                "fixed price component and an airfare component. The airfare component is " +
                "based on the flight hours flown and corresponds to the engine running time. It" +
                " can be seen from the display of the engine running time in the cockpit.");
            String body4Str = "\n\nBase price (net): " + transaction.totalCost.ToString("C", CultureInfo.CurrentCulture) +
                "\n19% VAT: " + (transaction.totalCost * (0.19)).ToString("C", CultureInfo.CurrentCulture) +
                "\nBasic price (gross): " + (transaction.totalCost + (transaction.totalCost * (0.19))).ToString("C", CultureInfo.CurrentCulture)
                + "\n\nAirfare per hour (net): " + transaction.aircraft.hourlyCost.ToString("C", CultureInfo.CurrentCulture) +
                "\n19% VAT: " + (transaction.aircraft.hourlyCost * (0.19)).ToString("C", CultureInfo.CurrentCulture) +
                "\nAirfare per hour (gross): " + (transaction.aircraft.hourlyCost + (transaction.aircraft.hourlyCost * (0.19))).ToString("C", CultureInfo.CurrentCulture) + "\n\n\n";
            Paragraph body4 = new Paragraph(body4Str);
            header.Alignment = Element.ALIGN_CENTER;
            body1.Alignment = Element.ALIGN_JUSTIFIED;
            body2.Alignment = Element.ALIGN_LEFT;
            body3.Alignment = Element.ALIGN_JUSTIFIED;
            body4.Alignment = Element.ALIGN_LEFT;
            pdfDocument.Add(header);
            pdfDocument.Add(body1);
            pdfDocument.Add(body2);
            pdfDocument.Add(body3);
            pdfDocument.Add(body4);
            pdfDocument.Add(new Paragraph("Date, Place                                                                                                                    Date, Place"));
            pdfDocument.Add(new Paragraph("RENTAJET                                                                                                                    " + transaction.customer.name));
            pdfDocument.Close();
        }
    }
}
